using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Multilanguage.Helper
{
    public static class AppResources
    {
        /* Com que la classe és "static", només es cridarà al constructor la primera vegada que s'utilitzi
            La variable estàtica es comparteix entre totes les instàncies o amb la pròpia classe, si és estàtica. 
            El constructor s'executa automàticament abans de la primera crida a qualsevol membre de la classe. Quan està instanciat no es torna a executar.
            static readonly ResourceManager resourceManager; assegura que resourceManager només es pot assignar dins el constructor estàtic, evitant que es modifiqui accidentalment més tard.
        */
        private static readonly ResourceManager _resourceManager;

        /// <summary>
        /// Creem gestor de recursos
        /// </summary>
        static AppResources()
        {
            // La localització dels recursos resx depèn del nom de l'aplicació (resourceName)
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name!;
            string resourceName = $"{assemblyName}.Resources.Resources";

            // Inicialitza el ResourceManager una vegada
            _resourceManager = new ResourceManager(resourceName, Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Retorna el text traduït segons la clau i l'idioma especificat
        /// </summary>
        public static string GetString(string key, string? cultureCode = null)
        {
            CultureInfo culture = cultureCode != null ? new CultureInfo(cultureCode) : CultureInfo.CurrentCulture;
            return _resourceManager.GetString(key, culture) ?? $"[Missing: {key}]";
        }
    }
}
