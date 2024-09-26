using Microsoft.AspNetCore.DataProtection;

namespace SoftwareTest_and_Security.Code
{
    public class SymetricEncryptionHandler
    {
        private readonly IDataProtector _dataProtector;

        public SymetricEncryptionHandler(IDataProtectionProvider protector)
        {
            _dataProtector = protector.CreateProtector("NielsErMinFavoritLære");
        }

        public string Protect(string textToEncrypt) => _dataProtector.Protect(textToEncrypt);

        public string UnProtect(string textToDecrypt) => _dataProtector.Unprotect(textToDecrypt);
    }
}
