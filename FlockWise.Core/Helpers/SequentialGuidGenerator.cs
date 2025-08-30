using System.Security.Cryptography;

namespace FlockWise.Core.Helpers;

public static class SequentialGuidGenerator
{
    private static readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

    public static Guid NewSequentialGuid()
    {
        var timestampBytes = BitConverter.GetBytes(DateTimeOffset.UtcNow.Ticks);

        var randomBytes = new byte[10];
        RandomNumberGenerator.GetBytes(randomBytes);
        
        var guidBytes = new byte[16];
        
        Buffer.BlockCopy(timestampBytes, 0, guidBytes, 0, 6);
        Buffer.BlockCopy(randomBytes, 0, guidBytes, 6, 10);

        if (BitConverter.IsLittleEndian)
        {
            SwapBytes(guidBytes, 0, 3);
            SwapBytes(guidBytes, 1, 2);
            SwapBytes(guidBytes, 4, 5);
        }
        
        guidBytes[7] = (byte) ((guidBytes[7] & 0x0F) | 0x40);
        
        guidBytes[8] = (byte) ((guidBytes[8] & 0x3F) | 0x80);
        
        return new Guid(guidBytes);
    }
    
    private static void SwapBytes(byte[] bytes, int left, int right)
    {
        (bytes[left], bytes[right]) = (bytes[right], bytes[left]);
    }

}