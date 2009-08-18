using System;
using System.Collections.Generic;
using FluentMigrator.Model;

namespace FluentMigrator.Expressions
{
	public class CreateIndexExpression : MigrationExpressionBase
	{
		public virtual IndexDefinition Index { get; set; }

		public CreateIndexExpression()
		{
			Index = new IndexDefinition();
		}

		public override void CollectValidationErrors(ICollection<string> errors)
		{
			Index.CollectValidationErrors(errors);
		}

		public override void ExecuteWith(IMigrationProcessor processor)
		{
			processor.Process(this);
		}

		public override IMigrationExpression Reverse()
		{
			return new DeleteIndexExpression { Index = Index.Clone() as IndexDefinition };
		}
	}
}