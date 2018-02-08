using ESFA.DC.ILR.ValidationService.ExternalData.ContPrefType.Interface;
using ESFA.DC.ILR.ValidationService.ExternalData.ContPrefType.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.ExternalData.ContPrefType
{
    public class ContactPreferenceDataService : IContactPreferenceDataService
    {
        private readonly IReadOnlyCollection<ContactPreference> _validContactPreferenceTypeCodesLookup;

        public ContactPreferenceDataService()
        {
            _validContactPreferenceTypeCodesLookup = new ReadOnlyCollection<ContactPreference>(new List<ContactPreference>()
            {
                new ContactPreference()
                {
                    Type = "PMC",
                    Code = 1,
                    ValidTo = new DateTime(2099, 12, 31)
                },
                new ContactPreference()
                {
                    Type = "PMC",
                    Code = 2,
                    ValidTo = new DateTime(2099, 12, 31)
                },
                new ContactPreference()
                {
                    Type = "PMC",
                    Code = 3,
                    ValidTo = new DateTime(2099, 12, 31)
                },
                new ContactPreference()
                {
                    Type = "RUI",
                    Code = 1,
                    ValidTo = new DateTime(2099, 12, 31)
                },
                new ContactPreference()
                {
                    Type = "RUI",
                    Code = 2,
                    ValidTo = new DateTime(2099, 12, 31)
                },
                new ContactPreference()
                {
                    Type = "RUI",
                    Code = 3,
                    ValidTo = new DateTime(2013, 07, 31)
                },
                new ContactPreference()
                {
                    Type = "RUI",
                    Code = 4,
                    ValidTo = new DateTime(2099, 12, 31)
                },
                new ContactPreference()
                {
                    Type = "RUI",
                    Code = 5,
                    ValidTo = new DateTime(2099, 12, 31)
                }
            });
        }

        public bool TypeExists(string type)
        {
            return _validContactPreferenceTypeCodesLookup.Any(x => x.Type == type);
        }

        public bool CodeExists(long? code)
        {
            if (!code.HasValue)
            {
                return false;
            }
            return _validContactPreferenceTypeCodesLookup.Any(x => x.Code == code.Value);
        }

        public bool TypeForCodesExist(string type, IEnumerable<long> codes, DateTime validTo )
        {
            if (string.IsNullOrWhiteSpace(type) || codes == null)
            {
                return false;
            }

            return _validContactPreferenceTypeCodesLookup.Any(x => x.Type == type && codes.Contains(x.Code) && validTo <= x.ValidTo);
        }
    }
}