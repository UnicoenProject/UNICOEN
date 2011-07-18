
class A{}
class B : A { }
class C<T>{}

interface IA<in T, out TResult> {
	public TResult Execute(T data);
}
interface IB<T> : IA<T, T> where T : IB<T>{}
interface IC <T> where T : class { }
interface ID <T> where T : struct { }
interface IE <T> where T : new() { }


