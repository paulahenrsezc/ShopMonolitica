using ShopMonolitica.Web.BL.Core;
using System.Text;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Entity
    {
        /// <summary>
        /// Clase generica para reducir codigo en entidades de Services
        /// </summary>
        public class EntityValidator<T>
        {
            /// <summary>
            /// Metodo generic para valirdar entidades
            /// </summary>
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
                var errorMessageBuilder = new StringBuilder();

                foreach (var property in properties)
                {
                    var value = property.GetValue(entity);
                    var propertyName = property.Name;

                    if (value is string && maxLength > 0 && ((string)value).Length > maxLength)
                    {
                        errorMessageBuilder.Append($"El valor de la propiedad '{propertyName}' de la entidad {typeof(T).Name} excede la longitud máxima de {maxLength} caracteres.\n");
                    }
                }
                /// <summary>
                /// Verificar si se encontraron errores
                /// </summary>
             
                if (errorMessageBuilder.Length > 0)
                {
                    result.Success = false;
                    result.Message = errorMessageBuilder.ToString();
                }
                else
                {
                    result.Success = true;
                    result.Message = "Validación exitosa";
                }

                return result;
            }
        }

    }
}
