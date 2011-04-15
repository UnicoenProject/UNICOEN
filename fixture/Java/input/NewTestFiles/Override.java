import java.io.OutputStream;
import java.io.IOException;
class BufferOutput {
	private OutputStream o;
	BufferOutput(OutputStream o) { this.o = o; }
	protected byte[] buf = new byte[512];
	protected int pos = 0;
	public void putchar(char c) throws IOException {
		if (pos == buf.length)
			flush();
		buf[pos++] = (byte)c;
	}
	public void putstr(String s) throws IOException {
		for (int i = 0; i < s.length(); i++)
			putchar(s.charAt(i));
	}
	public void flush() throws IOException {
		o.write(buf, 0, pos);
		pos = 0;
	}
}
class LineBufferOutput extends BufferOutput {
	LineBufferOutput(OutputStream o) { super(o); }
	public void putchar(char c) throws IOException {
		super.putchar(c);
		if (c == '\n')
			flush();
	}
}
class Override {
	public static void main(String[] args)
		throws IOException
	{
		LineBufferOutput lbo =
			new LineBufferOutput(System.out);
		lbo.putstr("lbo\nlbo");
		System.out.print("print\n");
		lbo.putstr("\n");
	}
}