namespace UserMgmtAPI.Application.Common.Interfaces
{
    public interface IEncryptionService
    {
        byte[] GenerateSaltedHash(byte[] plainText, byte[] salt);

        bool CompareByteArrays(byte[] array1, byte[] array2);
    }
}
