using System.Collections.ObjectModel;

namespace TimesheetManagement.Service.Areas.HelpPage.ModelDescriptions
{
	public class ComplexTypeModelDescription : ModelDescription
	{
		public Collection<ParameterDescription> Properties { get; private set; }

		public ComplexTypeModelDescription()
		{
			this.Properties = new Collection<ParameterDescription>();
		}
	}
}
