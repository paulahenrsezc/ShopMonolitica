using ShopMonolitica.Web.BL.Core;
using System.Text;

namespace ShopMonolitica.Web.Data.Entities
{
    public class EntityValidatorCategories
    {
        public class EntityValidator<T>
        {
            public static ServiceResult Validate(T entity, int maxLength = 0)
            {
                ServiceResult result = new ServiceResult();

                if (entity == null)
                {
                    result.Success = false;
                    result.Message = $"La entidad de tipo {typeof(T).Name} no puede ser nula";
                    return result;
                }

                var properties = typeof(T).GetProperties();
                var hasErrors = false;
                var errorMessageBuilder = new StringBuilder();

                foreach (var property in properties)
                {
                    var value = property.GetValue(entity);
                    var propertyName = property.Name;

                    if (value is string && maxLength > 0 && ((string)value).Length > maxLength)
                    {
                        hasErrors = true;
                        errorMessageBuilder.Append($"El valor de la propiedad '{propertyName}' de la entidad {typeof(T).Name} excede la longitud máxima de {maxLength} caracteres.\n");
                    }
                }

                result.Success = !hasErrors;
                result.Message = errorMessageBuilder.ToString();
                return result;
            }

        }
    }
}
