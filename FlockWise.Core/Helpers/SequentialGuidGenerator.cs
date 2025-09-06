using System.Security.Cryptography;

namespace FlockWise.Core.Helpers;

public static class SequentialGuidGenerator
{
    private static readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

    public static Guid NewSequentialGuid()
    {
        // Use UUIDv7 for time-ordered GUIDs that sort correctly as canonical strings.
        return NewUuid7Guid();
    }

    // RFC 9562 UUIDv7 generator
    public static Guid NewUuid7Guid()
    {
        // Build canonical big-endian UUID bytes (as they appear in the string form),
        // then adjust for Guid's internal little-endian layout for the first 3 fields.
        Span<byte> uuid = stackalloc byte[16];

        // 1) 48-bit Unix timestamp in milliseconds (big-endian)
        ulong ts = (ulong)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() & 0x0000FFFFFFFFFFFFUL;
        uuid[0] = (byte)((ts >> 40) & 0xFF);
        uuid[1] = (byte)((ts >> 32) & 0xFF);
        uuid[2] = (byte)((ts >> 24) & 0xFF);
        uuid[3] = (byte)((ts >> 16) & 0xFF);
        uuid[4] = (byte)((ts >> 8) & 0xFF);
        uuid[5] = (byte)(ts & 0xFF);

        // 2) 12-bit rand_a and 62-bit rand_b
        Span<byte> rnd = stackalloc byte[10];
        RandomNumberGenerator.GetBytes(rnd);

        // rand_a = 12 bits from rnd[0..1]
        ushort randA = (ushort)((rnd[0] << 8) | rnd[1]);

        // time_hi_and_version: upper 4 bits = 0b0111 (version 7), lower 12 bits = high 12 bits of rand_a
        uuid[6] = (byte)(0x70 | ((randA >> 8) & 0x0F)); // version in high nibble, top 4 bits of rand_a in low nibble
        uuid[7] = (byte)(randA & 0xFF);                 // remaining 8 bits of rand_a

        // rand_b: 62 bits from rnd[2..9], with RFC 4122 variant in the top 2 bits of uuid[8]
        uuid[8] = (byte)((rnd[2] & 0x3F) | 0x80); // set variant to 0b10xxxxxx
        uuid[9] = rnd[3];
        uuid[10] = rnd[4];
        uuid[11] = rnd[5];
        uuid[12] = rnd[6];
        uuid[13] = rnd[7];
        uuid[14] = rnd[8];
        uuid[15] = rnd[9];

        // Convert canonical big-endian bytes to Guid's expected internal layout:
        // Guid(byte[]) expects little-endian for the first 4+2+2 bytes.
        if (BitConverter.IsLittleEndian)
        {
            Swap(uuid, 0, 3);
            Swap(uuid, 1, 2);
            Swap(uuid, 4, 5);
            Swap(uuid, 6, 7);
        }

        return new Guid(uuid);
    }

    private static void Swap(Span<byte> bytes, int left, int right)
    {
        (bytes[left], bytes[right]) = (bytes[right], bytes[left]);
    }
}