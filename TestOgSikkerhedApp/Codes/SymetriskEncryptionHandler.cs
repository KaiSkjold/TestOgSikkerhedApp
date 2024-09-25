using Microsoft.AspNetCore.DataProtection;

namespace TestOgSikkerhedApp.Codes;

public class SymetriskEncryptionHandler
{
    private readonly IDataProtector _dataProtector;

    public SymetriskEncryptionHandler(IDataProtectionProvider protector)
    {
        
        _dataProtector = protector.CreateProtector("PlaceHolderKey");
    }

    public string Protect(string textToEncrypt) => _dataProtector.Protect(textToEncrypt);

    public string Unprotect(string textToDecrypt) => _dataProtector.Unprotect(textToDecrypt);

}
