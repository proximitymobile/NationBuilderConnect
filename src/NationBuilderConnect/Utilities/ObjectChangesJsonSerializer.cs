using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NationBuilderConnect.Resources.Entities;
using NationBuilderConnect.Resources.Requests;
using NationBuilderConnect.Utilities.Extensions;
using NationBuilderConnect.Utilities.Json.Resolvers;
using Newtonsoft.Json;

namespace NationBuilderConnect.Utilities
{
    public class ObjectChangesJsonSerializer
    {
        public static string SerializeChangesToJson<T>(T initialEntity, T changedEntity) where T : class, ITracksChanges
        {
            Ensure.IsNotNull(changedEntity, nameof(changedEntity));

            initialEntity = initialEntity ?? (T) GetDefaultTracksChangesInstance(typeof (T));

            var jsonResolver = new ExplicitInclusionContractResolver();

            var changedProperties = GetChangedProperties(initialEntity, changedEntity);

            foreach (var entity in changedProperties)
            {
                jsonResolver.Include(entity.Entity, entity.JsonPropertyNames);
            }

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = jsonResolver
            };
            return JsonConvert.SerializeObject(changedEntity, jsonSettings);
        }

        private static IEnumerable<TrackableWithJsonPropertyName> GetChangedProperties<T>(T initialEntity,
            T changedEntity) where T : class, ITracksChanges
        {
            if (changedEntity == null) return new List<TrackableWithJsonPropertyName>();

            var properties = GetSerializableProperties(changedEntity.GetType());

            var propertiesForThisEntity = new TrackableWithJsonPropertyName(changedEntity, new List<string>());

            var allPropertiesToInclude = new List<TrackableWithJsonPropertyName>
            {
                propertiesForThisEntity
            };

            foreach (var property in properties)
            {
                var initialValue = initialEntity != null ? property.Property.GetValue(initialEntity, null) : null;
                var changedValue = property.Property.GetValue(changedEntity, null);

                // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
                if (changedValue is ITracksChanges)
                {
                    initialValue = initialValue ?? GetDefaultTracksChangesInstance(changedValue.GetType());
                    propertiesForThisEntity.JsonPropertyNames.Add(property.Attribute.PropertyName);
                    allPropertiesToInclude.AddRange(GetChangedProperties((ITracksChanges) initialValue,
                        (ITracksChanges) changedValue));
                    continue;
                }

                if (initialValue == null && changedValue == null) continue;
                if (initialValue != null && changedValue != null && initialValue.Equals(changedValue)) continue;

                propertiesForThisEntity.JsonPropertyNames.Add(property.Attribute.PropertyName);
            }

            return allPropertiesToInclude;
        }

        private static IEnumerable<PropertyWithJsonAttribute> GetSerializableProperties(Type type)
        {
#if NET40
            return type
                .GetProperties()
                .Select(p => new PropertyWithJsonAttribute(p, p.GetAttribute<JsonPropertyAttribute>()))
                .Where(pa => pa.Attribute != null)
                .ToList();
#else
            return type.GetTypeInfo()
                .DeclaredProperties
                .Select(p => new PropertyWithJsonAttribute(p, p.GetAttribute<JsonPropertyAttribute>()))
                .Where(pa => pa.Attribute != null)
                .ToList();
#endif
        }

        private static ITracksChanges GetDefaultTracksChangesInstance(Type type)
        {
            if (type == typeof (PersonUpdate)) return new PersonUpdate();
            if (type == typeof (PersonAddressUpdate)) return new PersonAddressUpdate();
            if (type == typeof (UpdatePersonRequest)) return new UpdatePersonRequest(null);
            if (type == typeof (CreatePersonRequest)) return new CreatePersonRequest(null);
            throw new InvalidOperationException("Unknown trackable type");
        }

        private class PropertyWithJsonAttribute
        {
            public PropertyWithJsonAttribute(PropertyInfo property, JsonPropertyAttribute attribute)
            {
                Property = property;
                Attribute = attribute;
            }

            public PropertyInfo Property { get; private set; }
            public JsonPropertyAttribute Attribute { get; private set; }
        }

        private class TrackableWithJsonPropertyName
        {
            public TrackableWithJsonPropertyName(ITracksChanges entity, List<string> jsonPropertyNames)
            {
                Entity = entity;
                JsonPropertyNames = jsonPropertyNames;
            }

            public ITracksChanges Entity { get; private set; }
            public List<string> JsonPropertyNames { get; private set; }
        }
    }
}