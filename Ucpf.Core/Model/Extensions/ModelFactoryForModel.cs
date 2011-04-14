namespace Ucpf.Core.Model.Extensions
{
	public static class ModelFactoryForModel
	{
		public static UnifiedArgument ToArgument(this IUnifiedExpression expression)
		{
			return UnifiedArgument.Create(expression);
		}

		public static UnifiedFunctionDefinition ToFunctionDefinition(this string name)
		{
			return UnifiedFunctionDefinition.CreateFunction(name);
		}

		public static UnifiedWhile ToWhile(this IUnifiedExpression condition)
		{
			return UnifiedWhile.Create(condition);
		}

		public static UnifiedDoWhile ToDoWhile(this IUnifiedExpression condition)
		{
			return UnifiedDoWhile.Create(condition);
		}

		public static UnifiedForeach ToForeach(this IUnifiedExpression set,
		                                       UnifiedType variableType,
		                                       string variableName)
		{
			return UnifiedForeach.Create(
				UnifiedVariableDefinition.CreateSingle(variableType, variableName),
				set
				);
		}

		public static UnifiedIf ToIf(this IUnifiedExpression condition)
		{
			return UnifiedIf.Create(condition);
		}

		public static UnifiedSpecialExpression ToReturn(this IUnifiedExpression value)
		{
			return UnifiedSpecialExpression.CreateReturn(value);
		}

		public static UnifiedCase ToCase(this IUnifiedExpression condtion)
		{
			return UnifiedCase.Create(condtion, UnifiedBlock.Create());
		}

		public static UnifiedSwitch ToSwitch(this IUnifiedExpression value)
		{
			return UnifiedSwitch.Create(value);
		}

		public static UnifiedTypeArgument ToTypeParameter(
			this IUnifiedExpression value)
		{
			return UnifiedTypeArgument.Create(value);
		}

		public static UnifiedNew ToNew(this UnifiedType type)
		{
			return UnifiedNew.Create(type);
		}
	}
}