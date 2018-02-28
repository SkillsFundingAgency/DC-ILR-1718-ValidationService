using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.LearnerValidationActor.Interfaces;
using ESFA.DC.ILR.ValidationService.Modules.Modules;
using ESFA.DC.ILR.ValidationService.Modules.Stubs;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace ESFA.DC.ILR.ValidationService.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunValidation();

            RunActor();
            
            System.Console.ReadLine();
        }

        private static void RunValidation()
        {
            var validationContext = new ValidationContextStub();

            var container = BuildContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var ruleSetOrchestrationService = scope.Resolve<IRuleSetOrchestrationService<ILearner, IValidationError>>();

                var result = ruleSetOrchestrationService.Execute(validationContext);
            }
        }
        
        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<ValidationServiceConsoleModule>();

            return containerBuilder.Build();
        }

        private static async void RunActor()
        {
            var tasks = new List<Task<int>>();

            for (var i = 0; i < 200; i++)
            {
                ILearnerValidationActor actor = ActorProxy.Create<ILearnerValidationActor>(ActorId.CreateRandom(), new Uri("fabric:/ESFA.DC.ILR.ValidationService.Application/LearnerValidationActorService"));

                var cancellationToken = new CancellationToken();
                tasks.Add(actor.Validate(cancellationToken));
            }

            Task.WaitAll(tasks.ToArray());

            var total = tasks.Sum(t => t.Result);
        }
    }
}
