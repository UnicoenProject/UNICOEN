public class Encapsulated{}

class Foo {
	private int _field1;
	private int _field2;
	
	public int getField1(){
		return _field1;
	}
	
	public int getField2(){
		return _field2;
	}
	
	public void setField1(int i) {
		this._field1 = i;
	}
	
	public void setField2(int i){
		this._field2 = i;
	}
}