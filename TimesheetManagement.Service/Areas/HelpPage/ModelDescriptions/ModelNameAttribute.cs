using System;

namespace TimesheetManagement.Service.Areas.HelpPage.ModelDescriptions
{
	/// <summary>
	///     Use this attribute to change the name of the <see cref="ModelDescription" /> generated for a type.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, Inherited = false)]
	public sealed class ModelNameAttribute : Attribute
	{
		public string Name { get; private set; }

		public ModelNameAttribute(string name)
		{
			this.Name = name;
		}
	}
}
