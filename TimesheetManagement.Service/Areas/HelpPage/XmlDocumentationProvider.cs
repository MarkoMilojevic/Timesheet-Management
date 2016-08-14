using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Xml.XPath;
using TimesheetManagement.Service.Areas.HelpPage.ModelDescriptions;

namespace TimesheetManagement.Service.Areas.HelpPage
{
	/// <summary>
	///     A custom <see cref="IDocumentationProvider" /> that reads the API documentation from an XML documentation file.
	/// </summary>
	public class XmlDocumentationProvider : IDocumentationProvider, IModelDocumentationProvider
	{
		private const string TypeExpression = "/doc/members/member[@name='T:{0}']";
		private const string MethodExpression = "/doc/members/member[@name='M:{0}']";
		private const string PropertyExpression = "/doc/members/member[@name='P:{0}']";
		private const string FieldExpression = "/doc/members/member[@name='F:{0}']";
		private const string ParameterExpression = "param[@name='{0}']";
		private readonly XPathNavigator documentNavigator;

		/// <summary>
		///     Initializes a new instance of the <see cref="XmlDocumentationProvider" /> class.
		/// </summary>
		/// <param name="documentPath">The physical path to XML document.</param>
		public XmlDocumentationProvider(string documentPath)
		{
			if (documentPath == null)
			{
				throw new ArgumentNullException("documentPath");
			}

			XPathDocument xpath = new XPathDocument(documentPath);
			this.documentNavigator = xpath.CreateNavigator();
		}

		public string GetDocumentation(HttpControllerDescriptor controllerDescriptor)
		{
			XPathNavigator typeNode = this.GetTypeNode(controllerDescriptor.ControllerType);
			return XmlDocumentationProvider.GetTagValue(typeNode, "summary");
		}

		public virtual string GetDocumentation(HttpActionDescriptor actionDescriptor)
		{
			XPathNavigator methodNode = this.GetMethodNode(actionDescriptor);
			return XmlDocumentationProvider.GetTagValue(methodNode, "summary");
		}

		public virtual string GetDocumentation(HttpParameterDescriptor parameterDescriptor)
		{
			ReflectedHttpParameterDescriptor reflectedParameterDescriptor = parameterDescriptor as ReflectedHttpParameterDescriptor;
			if (reflectedParameterDescriptor != null)
			{
				XPathNavigator methodNode = this.GetMethodNode(reflectedParameterDescriptor.ActionDescriptor);
				if (methodNode != null)
				{
					string parameterName = reflectedParameterDescriptor.ParameterInfo.Name;
					XPathNavigator parameterNode =
						methodNode.SelectSingleNode(string.Format(CultureInfo.InvariantCulture, XmlDocumentationProvider.ParameterExpression, parameterName));
					if (parameterNode != null)
					{
						return parameterNode.Value.Trim();
					}
				}
			}

			return null;
		}

		public string GetResponseDocumentation(HttpActionDescriptor actionDescriptor)
		{
			XPathNavigator methodNode = this.GetMethodNode(actionDescriptor);
			return XmlDocumentationProvider.GetTagValue(methodNode, "returns");
		}

		public string GetDocumentation(MemberInfo member)
		{
			string memberName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", XmlDocumentationProvider.GetTypeName(member.DeclaringType), member.Name);
			string expression = member.MemberType == MemberTypes.Field ? XmlDocumentationProvider.FieldExpression : XmlDocumentationProvider.PropertyExpression;
			string selectExpression = string.Format(CultureInfo.InvariantCulture, expression, memberName);
			XPathNavigator propertyNode = this.documentNavigator.SelectSingleNode(selectExpression);
			return XmlDocumentationProvider.GetTagValue(propertyNode, "summary");
		}

		public string GetDocumentation(Type type)
		{
			XPathNavigator typeNode = this.GetTypeNode(type);
			return XmlDocumentationProvider.GetTagValue(typeNode, "summary");
		}

		private XPathNavigator GetMethodNode(HttpActionDescriptor actionDescriptor)
		{
			ReflectedHttpActionDescriptor reflectedActionDescriptor = actionDescriptor as ReflectedHttpActionDescriptor;
			if (reflectedActionDescriptor != null)
			{
				string selectExpression = string.Format(CultureInfo.InvariantCulture, XmlDocumentationProvider.MethodExpression,
					XmlDocumentationProvider.GetMemberName(reflectedActionDescriptor.MethodInfo));
				return this.documentNavigator.SelectSingleNode(selectExpression);
			}

			return null;
		}

		private static string GetMemberName(MethodInfo method)
		{
			string name = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", XmlDocumentationProvider.GetTypeName(method.DeclaringType), method.Name);
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length != 0)
			{
				string[] parameterTypeNames = parameters.Select(param => XmlDocumentationProvider.GetTypeName(param.ParameterType)).ToArray();
				name += string.Format(CultureInfo.InvariantCulture, "({0})", string.Join(",", parameterTypeNames));
			}

			return name;
		}

		private static string GetTagValue(XPathNavigator parentNode, string tagName)
		{
			if (parentNode != null)
			{
				XPathNavigator node = parentNode.SelectSingleNode(tagName);
				if (node != null)
				{
					return node.Value.Trim();
				}
			}

			return null;
		}

		private XPathNavigator GetTypeNode(Type type)
		{
			string controllerTypeName = XmlDocumentationProvider.GetTypeName(type);
			string selectExpression = string.Format(CultureInfo.InvariantCulture, XmlDocumentationProvider.TypeExpression, controllerTypeName);
			return this.documentNavigator.SelectSingleNode(selectExpression);
		}

		private static string GetTypeName(Type type)
		{
			string name = type.FullName;
			if (type.IsGenericType)
			{
				// Format the generic type name to something like: Generic{System.Int32,System.String}
				Type genericType = type.GetGenericTypeDefinition();
				Type[] genericArguments = type.GetGenericArguments();
				string genericTypeName = genericType.FullName;

				// Trim the generic parameter counts from the name
				genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
				string[] argumentTypeNames = genericArguments.Select(t => XmlDocumentationProvider.GetTypeName(t)).ToArray();
				name = string.Format(CultureInfo.InvariantCulture, "{0}{{{1}}}", genericTypeName, string.Join(",", argumentTypeNames));
			}
			if (type.IsNested)
			{
				// Changing the nested type name from OuterType+InnerType to OuterType.InnerType to match the XML documentation syntax.
				name = name.Replace("+", ".");
			}

			return name;
		}
	}
}
