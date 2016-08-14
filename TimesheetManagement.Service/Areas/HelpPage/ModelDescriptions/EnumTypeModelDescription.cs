using System.Collections.ObjectModel;

namespace TimesheetManagement.Service.Areas.HelpPage.ModelDescriptions
{
	public class EnumTypeModelDescription : ModelDescription
	{
		public Collection<EnumValueDescription> Values { get; private set; }

		public EnumTypeModelDescription()
		{
			this.Values = new Collection<EnumValueDescription>();
		}
	}
}
