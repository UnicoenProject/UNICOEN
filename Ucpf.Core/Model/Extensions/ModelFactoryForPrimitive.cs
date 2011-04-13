namespace Ucpf.Core.Model.Extensions
{
	public static class ModelFactoryForPrimitive
	{
		public static UnifiedIdentifier ToVariable(this string name)
		{
			return UnifiedIdentifier.CreateUnknown(name);
		}

		public static UnifiedVariableDefinition ToVariableDefinition(this string name)
		{
			return UnifiedVariableDefinition.Create(name);
		}

		public static UnifiedVariableDefinition ToVariableDefinition(this string name,
		                                                             UnifiedType type)
		{
			return UnifiedVariableDefinition.Create(type, name);
		}

		public static UnifiedVariableDefinition ToVariableDefinition(this string name,
		                                                             IUnifiedExpression
		                                                             	initialValue)
		{
			return UnifiedVariableDefinition.Create(name, initialValue);
		}

		public static UnifiedVariableDefinition ToVariableDefinition(this string name,
		                                                             UnifiedType type,
		                                                             IUnifiedExpression
		                                                             	initialValue)
		{
			return UnifiedVariableDefinition.Create(type, name, initialValue);
		}

		public static UnifiedType ToType(this string name)
		{
			return UnifiedType.CreateUsingString(name);
		}

		public static UnifiedClassDefinition ToClassDefinition(this string name)
		{
			return UnifiedClassDefinition.CreateClass(name);
		}

		public static UnifiedBooleanLiteral ToLiteral(this bool literal)
		{
			return UnifiedBooleanLiteral.Create(literal);
		}

		public static UnifiedIntegerLiteral ToLiteral(this int value)
		{
			return UnifiedIntegerLiteral.Create(value);
		}

		public static UnifiedDecimalLiteral ToLiteral(this double value)
		{
			return UnifiedDecimalLiteral.Create(value);
		}
	}
}