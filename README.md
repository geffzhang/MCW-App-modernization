# 应用现代化

Contoso，Ltd.（Contoso）是一家从事旧业务的新公司。这家公司 2011年在新西兰奥克兰成立，提供全方位的长期保险服务，以帮助投保不足的个人，填补其创始人在市场中所看到的空白。从公司成立，它们的增长速度就超出了预期，并努力应对快速增长。仅在第一年，他们就增加了100多名新员工，以满足他们对服务的需求。为了管理策略和相关文档，他们使用自定义开发的Windows Forms应用程序，称为PolicyConnect。PolicyConnect使用本地SQL Server 2008 R2数据库作为其数据存储，并使用其局域网上的文件服务器存储策略文档。该应用程序及其用于管理策略的基础流程变得越来越过载。

Contoso最近启动了一个新的Web和移动项目，以使保单持有人，经纪人和员工无需通过问Contoso网络的VPN连接即可访问策略信息。该Web项目是.NET Core 3.1 MVC Web应用程序，它使用REST API访问PolicyConnect数据库。他们最终打算在所有应用程序中共享REST API，包括移动应用程序和PolicyConnect的WinForms版本。他们拥有在本地运行的Web应用程序的原型，并且有兴趣通过将应用程序托管在云中来进一步推进其现代化工作。但是，由于他们没有使用云的经验，因此他们不知道如何利用云的所有托管服务。

他们还没有开始开发移动应用程序。Contoso正在寻找有关如何采用对.NET开发人员友好的方法在Android和iOS上实施PolicyConnect移动应用程序的指南。

为了准备在云中托管其应用程序，他们希望将其SQL Server数据库迁移到Azure中的PaaS SQL服务。Contoso希望利用Azure中完全托管的SQL服务中提供的高级安全功能。通过迁移到云，他们希望提高其技术能力，并利用迁移到云中实现的增强功能和服务。他们希望添加的新功能包括：从经纪人自动转发文档，对经纪人的安全访问，对策略信息的访问以及为分散的员工提供可靠的策略检索。他们已经清楚他们将继续在本地使用PolicyConnect WinForms应用程序，但希望更新该应用程序以使用基于云的API和服务。  

2020 年6月

## 目标受众

- 应用程序开发人员

## 摘要

### 研讨会

在本研讨会中，您将通过利用云服务更好地理解 对本地老的应用程序和基础架构进行现代化所涉及的步骤。您还将看到如何通过添加Web和移动服务的组合来增强应用程序，所有这些都使用Azure Active Directory保护。

在本研讨会结束时，将提高您为希望将服务从本地迁移到云的组织设计和实施现代化计划的能力。


### 白板设计会议

在此白板设计会议中，您将与一个小组一起设计一种解决方案，以通过利用云服务来现代化旧式本地应用程序和基础架构。作为现代化工作的一部分，使用Web和移动服务的组合添加了应用程序增强功能，所有这些功能都使用Azure Active Directory保护。

在本白板设计课程的最后，您将提高为希望将服务从本地迁移到云的组织设计现代化计划的能力。

### 动手实验

在此动手实验中，您将实现 一个 老式本地应用程序 进行现代化改造的步骤，包括将数据库升级和迁移到Azure以及更新应用程序以利用无服务器和云服务。

在本动手实验的最后，您将提高构建解决方案的能力，以使使用云服务的老式本地应用程序和基础结构现代化。

## Azure 服务和相关产品

- API Management
- App Services
- Azure Active Directory
- Azure Cognitive Services
- Azure Database Migration Service
- Azure Key Vault
- Azure Redis
- Azure Cognitive Search
- Azure SQL Database
- Azure Storage
- Azure Virtual Machines
- Flow
- PowerApps
- Visual Studio
- Xamarin

## Related references

- [MCW](https://microsoftcloudworkshop.com)
- [Reference architecture for Managed Web Applications](https://docs.microsoft.com/azure/architecture/reference-architectures/app-service-web-app/basic-web-app)
- [Azure application architecture guide](https://docs.microsoft.com/azure/architecture/guide/)

## Help & Support

We welcome feedback and comments from Microsoft SMEs & learning partners who deliver MCWs.

**_Having trouble?_**

- First, verify you have followed all written lab instructions (including the Before the Hands-on lab document).
- Next, submit an issue with a detailed description of the problem.
- Do not submit pull requests. Our content authors will make all changes and submit pull requests for approval.

If you are planning to present a workshop, _review and test the materials early_! We recommend at least two weeks prior.

### Please allow 5 - 10 business days for review and resolution of issues.
