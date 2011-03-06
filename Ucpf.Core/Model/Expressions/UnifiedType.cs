namespace Ucpf.Core.Model.Expressions {
	public class UnifiedType {
		public string Name { get; set; }

		public static UnifiedType Create(string name) {
			return new UnifiedType {
				Name = name,
			};
		}
	}
}
