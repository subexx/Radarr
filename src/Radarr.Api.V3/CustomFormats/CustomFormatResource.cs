using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NzbDrone.Core.CustomFormats;
using Radarr.Http.ClientSchema;
using Radarr.Http.REST;

namespace Radarr.Api.V3.CustomFormats
{
    public class CustomFormatResource : RestResource
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public override int Id { get; set; }
        public string Name { get; set; }
        public bool? IncludeCustomFormatWhenRenaming { get; set; }
        public List<CustomFormatSpecificationSchema> Specifications { get; set; }
    }

    public static class CustomFormatResourceMapper
    {
        public static CustomFormatResource ToResource(this CustomFormat model, bool includeDetails)
        {
            var resource = new CustomFormatResource
            {
                Id = model.Id,
                Name = model.Name
            };

            if (includeDetails)
            {
                resource.IncludeCustomFormatWhenRenaming = model.IncludeCustomFormatWhenRenaming;
                resource.Specifications = model.Specifications.Select(x => x.ToSchema()).ToList();
            }

            return resource;
        }

        public static List<CustomFormatResource> ToResource(this IEnumerable<CustomFormat> models, bool includeDetails)
        {
            return models.Select(m => m.ToResource(includeDetails)).ToList();
        }

        public static CustomFormat ToModel(this CustomFormatResource resource, List<ICustomFormatSpecification> specifications)
        {
            return new CustomFormat
            {
                Id = resource.Id,
                Name = resource.Name,
                IncludeCustomFormatWhenRenaming = resource.IncludeCustomFormatWhenRenaming ?? false,
                Specifications = resource.Specifications?.Select(x => MapSpecification(x, specifications)).ToList() ?? new List<ICustomFormatSpecification>()
            };
        }

        private static ICustomFormatSpecification MapSpecification(CustomFormatSpecificationSchema resource, List<ICustomFormatSpecification> specifications)
        {
            var matchingSpec =
                specifications.SingleOrDefault(x => x.GetType().Name == resource.Implementation);

            if (matchingSpec is null)
            {
                throw new ArgumentException(
                    $"{resource.Implementation} is not a valid specification implementation");
            }

            var type = matchingSpec.GetType();

            var spec = (ICustomFormatSpecification)SchemaBuilder.ReadFromSchema(resource.Fields, type);
            spec.Name = resource.Name;
            spec.Negate = resource.Negate;
            spec.Required = resource.Required;
            return spec;
        }
    }
}
