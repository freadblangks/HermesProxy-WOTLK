using System.Linq;
using Framework.Cryptography;

namespace HermesProxy.World.Client;

public class TbcWorldCrypt : LegacyWorldCrypt
{
	public const uint CRYPTED_SEND_LEN = 6u;

	public const uint CRYPTED_RECV_LEN = 4u;

	private byte[] m_key;

	private byte m_send_i;

	private byte m_send_j;

	private byte m_recv_i;

	private byte m_recv_j;

	private bool m_isInitialized;

	public void Initialize(byte[] sessionKey)
	{
		byte[] recvSeed = new byte[16]
		{
			56, 167, 131, 21, 248, 146, 37, 48, 113, 152,
			103, 177, 140, 4, 226, 170
		};
		HmacHash recvHash = new HmacHash(recvSeed);
		recvHash.Finish(sessionKey, sessionKey.Count());
		this.m_key = recvHash.Digest.ToArray();
		this.m_send_i = (this.m_send_j = (this.m_recv_i = (this.m_recv_j = 0)));
		this.m_isInitialized = true;
	}

	public void Decrypt(byte[] data, int len)
	{
		if ((long)len >= 4L)
		{
			byte t = 0;
			while ((uint)t < 4u)
			{
				this.m_recv_i %= (byte)this.m_key.Count();
				byte x = (byte)((data[t] - this.m_recv_j) ^ this.m_key[this.m_recv_i]);
				this.m_recv_i++;
				this.m_recv_j = data[t];
				data[t] = x;
				t++;
			}
		}
	}

	public void Encrypt(byte[] data, int len)
	{
		if (this.m_isInitialized && (long)len >= 6L)
		{
			byte t = 0;
			while ((uint)t < 6u)
			{
				this.m_send_i %= (byte)this.m_key.Count();
				byte x = (byte)((data[t] ^ this.m_key[this.m_send_i]) + this.m_send_j);
				this.m_send_i++;
				data[t] = (this.m_send_j = x);
				t++;
			}
		}
	}
}
