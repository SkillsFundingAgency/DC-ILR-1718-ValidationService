using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;
using ESFA.DC.ILR.ValidationService.LearnerValidationActor.Interfaces;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.RuleSet;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Modules.Stubs;

namespace ESFA.DC.ILR.ValidationService.LearnerValidationActor
{
    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    public class LearnerValidationActor : Actor, ILearnerValidationActor
    {
        private readonly ILifetimeScope _lifetimeScope;

        /// <summary>
        /// Initializes a new instance of LearnerValidationActor
        /// </summary>
        /// <param name="actorService">The Microsoft.ServiceFabric.Actors.Runtime.ActorService that will host this actor instance.</param>
        /// <param name="actorId">The Microsoft.ServiceFabric.Actors.ActorId for this actor instance.</param>
        public LearnerValidationActor(ActorService actorService, ActorId actorId, ILifetimeScope lifetimeScope)
            : base(actorService, actorId)
        {
            _lifetimeScope = lifetimeScope;
        }

        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            //register autofac

            ActorEventSource.Current.ActorMessage(this, "Actor activated.");

            // The StateManager is this actor's private state store.
            // Data stored in the StateManager will be replicated for high-availability for actors that use volatile or persisted state storage.
            // Any serializable object can be saved in the StateManager.
            // For more information, see https://aka.ms/servicefabricactorsstateserialization

            return this.StateManager.TryAddStateAsync("count", 0);
        }
        
        public Task<int> Validate(CancellationToken cancellationToken)
        {
            using (var childLifetimeScope = _lifetimeScope.BeginLifetimeScope())
            {
                var validationOrchestrationService = childLifetimeScope.Resolve<IRuleSetOrchestrationService<ILearner>>();

                validationOrchestrationService.Execute(new ValidationContextStub());

                var validationErrorHandler = childLifetimeScope.Resolve<IValidationErrorHandler>();

                return Task.FromResult(1);
            }
        }
    }
}
