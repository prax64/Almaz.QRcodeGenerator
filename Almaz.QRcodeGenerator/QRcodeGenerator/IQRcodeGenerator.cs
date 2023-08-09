namespace Almaz.QRcodeGenerator.QRcodeGenerator
{
    public interface IQRcodeGenerator
    {
        byte[] GenerateQRCode(string text);
    }
}
