using QRCoder;

namespace Almaz.QRcodeGenerator.QRcodeGenerator
{
    public class QRcodeGenerator : IQRcodeGenerator
    {
        public byte[] GenerateQRCode(string text)
        {
            byte[] QRcode = new byte[0] ;
            if(!string.IsNullOrEmpty(text))
            {
                QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

                BitmapByteQRCode bitmap = new BitmapByteQRCode(qrCodeData);
                QRcode = bitmap.GetGraphic(20);
            }
            return QRcode;
        }
    }
}
