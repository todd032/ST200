using System ;

public static class LoadingWindows {
	
	private static void code(uint[] v, uint[] k) {
    	uint y = v[0];
    	uint z = v[1];
	    uint sum = 0;
	    uint delta=0x9e3779b9;
	    uint n=32;
	
	    while(n-->0)
	    {
	        y += (z << 4 ^ z >> 5) + z ^ sum + k[sum & 3];
	        sum += delta;
	        z += (y << 4 ^ y >> 5) + y ^ sum + k[sum >> 11 & 3];
	    }
	
	    v[0]=y;
	    v[1]=z;
	}
	
	private static void decode(uint[] v, uint[] k) {
	    uint n=32;
	    uint sum;
	    uint y=v[0];
	    uint z=v[1];
	    uint delta=0x9e3779b9;
	
	    sum = delta << 5 ;
	
	    while(n-->0)
	    {
	        z -= (y << 4 ^ y >> 5) + y ^ sum + k[sum >> 11 & 3];
	        sum -= delta;
	        y -= (z << 4 ^ z >> 5) + z ^ sum + k[sum & 3];
	    }
	
	    v[0]=y;
	    v[1]=z;
	}
	
	public static string NextE(string Data, string Key) {
		
		byte[] encodingKey = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
		uint[] formattedKey = new uint[encodingKey.Length];
		 for(int i = 0;i < encodingKey.Length;i++) 
		 {
		     formattedKey[i] = Convert.ToUInt32(encodingKey[i]);
		 }
		
		
	    if(Data.Length%2!=0) Data += '\0'; // Make sure array is even in length.
	    byte[] dataBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(Data);
		//byte[] dataBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(Data);
		//byte[] dataBytes = System.Text.UTF8Encoding.UTF8.GetBytes(Data);
		
		
	    string cipher = string.Empty;
	    uint[] tempData = new uint[2];
	    for(int i=0; i<dataBytes.Length; i+=2)
	    {
	        tempData[0] = dataBytes[i];
	        tempData[1] = dataBytes[i+1];
	        code(tempData, formattedKey);
	        cipher += ConvertUIntToString(tempData[0]) + 
	                          ConvertUIntToString(tempData[1]);
	    }
	
	    return cipher;
	}
	
	
	public static string NextD(string Data, string Key) {
		
		byte[] encodingKey = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
		uint[] formattedKey = new uint[encodingKey.Length];
		 for(int i = 0;i < encodingKey.Length;i++) 
		 {
		     formattedKey[i] = Convert.ToUInt32(encodingKey[i]);
		 }
		
		
		
	    int x = 0;
	    uint[] tempData = new uint[2];
	    byte[] dataBytes = new byte[Data.Length / 8 * 2];
	    for(int i=0; i<Data.Length; i+=8)
	    {
	        tempData[0] = ConvertStringToUInt(Data.Substring(i, 4));
	        tempData[1] = ConvertStringToUInt(Data.Substring(i+4, 4));
	        decode(tempData, formattedKey);
	        dataBytes[x++] = (byte)tempData[0];
	        dataBytes[x++] = (byte)tempData[1];
	    }
	
		
	    string decipheredString = System.Text.ASCIIEncoding.ASCII.GetString(dataBytes, 0, dataBytes.Length);
		
		//string decipheredString = System.Text.UnicodeEncoding.Unicode.GetString(dataBytes, 0, dataBytes.Length) ;
		//string decipheredString = System.Text.UTF8Encoding.UTF8.GetString(dataBytes, 0, dataBytes.Length);
		
	    // Strip the null char if it was added.
	    if(decipheredString[decipheredString.Length - 1] == '\0')
	        decipheredString = decipheredString.Substring(0, 
	                                                decipheredString.Length - 1);
	    return decipheredString;
	}
	
	private static string ConvertUIntToString(uint Input){
	    System.Text.StringBuilder output = new System.Text.StringBuilder();
	    output.Append((char)((Input & 0xFF)));
	    output.Append((char)((Input >> 8) & 0xFF));
	    output.Append((char)((Input >> 16) & 0xFF));
	    output.Append((char)((Input >> 24) & 0xFF));
	    return output.ToString();
	}
	
	private static uint ConvertStringToUInt(string Input) {
	    uint output;
	    output =  ((uint)Input[0]);
	    output += ((uint)Input[1] << 8);
	    output += ((uint)Input[2] << 16);
	    output += ((uint)Input[3] << 24);
	    return output;
	}
	
	
}


