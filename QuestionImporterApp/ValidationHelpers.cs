using QuestionImporterApp.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionImporterApp
{
    public class ValidationType
    {
        public ValidationType(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; private set; }
        public Type Type { get; private set; }
    }

    static public class ValidationHelpers
    {
        static public List<ValidationType> GetValidations()
        {
            var retVal = new List<ValidationType>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var allTypes = assembly.GetTypes();//System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
                foreach (Type type in allTypes.Where(x => x.GetInterfaces().Contains(typeof(IValidation))))
                {
                    var factory = Activator.CreateInstance(type) as IValidation;

                    if (factory != null)
                    {
                        retVal.Add(new ValidationType(factory.Name, type));
                    }
                }
            }

            return retVal;
        }
    }
}
