using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NationBuilderConnect.Client.Utilities.Json
{
    /// <summary>
    ///     Allows us to select which properties to include in JSON serialization
    /// </summary>
    public class ExplicitInclusionContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<ITracksChanges, HashSet<string>> _includes;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExplicitInclusionContractResolver" /> class
        /// </summary>
        public ExplicitInclusionContractResolver()
        {
            _includes = new Dictionary<ITracksChanges, HashSet<string>>();
        }

        /// <summary>
        ///     Include a property
        /// </summary>
        /// <param name="entity">The entity to include the property for</param>
        /// <param name="jsonPropertyNames">The name of the property (in the JSON)</param>
        public void Include(ITracksChanges entity, IEnumerable<string> jsonPropertyNames)
        {
            if (entity == null) return;

            HashSet<string> includesForEntity;

            if (!_includes.TryGetValue(entity, out includesForEntity))
                includesForEntity = _includes[entity] = new HashSet<string>();

            foreach (var prop in jsonPropertyNames)
            {
                includesForEntity.Add(prop);
            }
        }

        private bool IsIncluded(ITracksChanges entity, string propertyName)
        {
            HashSet<string> includesForEntity;
            return _includes.TryGetValue(entity, out includesForEntity) && includesForEntity.Contains(propertyName);
        }

        /// <inheritDoc />
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var currentShouldSerialize = property.ShouldSerialize;
            property.ShouldSerialize =
                instance =>
                    (currentShouldSerialize == null || currentShouldSerialize(instance)) &&
                    IsIncluded(instance as ITracksChanges, property.PropertyName);
            return property;
        }
    }
}