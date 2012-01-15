class EncapsulateCollection{
}
class Foo{
	private int[] _collection;
	
	public int[] getCollection(){
		return _collection;
	}
	
	public void setCollection(int[] collection){
		_collection = collection;
	}
}

class Bar{
	private List<Integer> _collection;
	
	public List<Integer> getCollection(){
		return _collection;
	}
	
	public void setCollection(List<Integer> collection){
		_collection = collection;
	}
}