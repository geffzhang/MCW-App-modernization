![Microsoft Cloud Workshops](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
应用现代化
</div>

<div class="MCWHeader2">
白板设计会议 学生指南
</div>

<div class="MCWHeader3">
June 2020
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2020 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents**

<!-- TOC -->

- [App modernization whiteboard design session student guide](#app-modernization-whiteboard-design-session-student-guide)
  - [摘要和学习目标](#摘要和学习目标)
  - [第一步: Review the customer case study](#第一步-review-the-customer-case-study)
    - [客户情况](#客户情况)
    - [客户需求](#客户需求)
    - [客户异议](#客户异议)
    - [常见场景的信息图](#常见场景的信息图)
  - [步骤 2: 设计一个概念验证解决方案](#步骤-2-设计一个概念验证解决方案)
  - [第三步: 提出解决方案](#第三步-提出解决方案)
  - [总结](#总结)
  - [Additional references](#additional-references)

<!-- /TOC -->

# App modernization whiteboard design session student guide

## 摘要和学习目标

在此白板设计会议中，您将与一个小组一起设计一种解决方案，以通过利用云服务来现代化旧式本地应用程序和基础架构。作为现代化工作的一部分，使用Web和移动服务的组合添加了应用程序增强功能，所有这些功能都使用Azure Active Directory保护。

在本白板设计课程的最后，您将提高为希望将服务从本地迁移到云的组织设计现代化计划的能力。

 
## 第一步: Review the customer case study

**Outcome**

分析客户需求.

时限: 15 分钟

指导：与所有参与者一起，主持人/ SME提供客户案例研究的概述以及技术提示.

1. 认识团队成员核培训师.

2. 阅读学生指南中步骤1-3的所有说明

3. 作为一个团队成员,  查看下列客户案例.

### 客户情况

Contoso，Ltd.（Contoso）是一家从事旧业务的新公司。该公司于2011年由高级人寿保险公司高管在新西兰奥克兰成立。这家雄心勃勃的新公司提供全方位的长期保险服务，以帮助未保险人群。

几乎从一开始，该公司的增长速度就远远超出了预期。大量的业务意味着为管理策略文档而创建的初始流程变得超负荷。即使头两年员工人数从5人增加到110人，员工们仍在努力应对。Contoso总经理Charlene Mathis说：“到2013年初，我们已在办公室归档了超过750,000页的部分手写政策文件。” “面对客户的员工无法快速检索策略，我们面临服务瓶颈。响应速度慢影响了客户服务，而快速找到文档的能力使我们浪费了时间和金钱。”

为了克服这些挑战，创建者启动了一个项目，以构建一个应用程序，该应用程序可以数字化并归档所有现有的策略文件，并在经纪人提交它们时归档新的策略。他们还要求允许从经纪人自动转发文档，对经纪人的安全访问，对策略信息的访问以及为分散工作人员准备的策略检索。该项目的结果是一个名为PolicyConnect的自定义Windows Form应用程序。Contoso员工使用PolicyConnect输入必要的保单元数据，包括保险金额，受益人信息，保单类型以及任何自付额和自付费用要求，并将其与数字化保单文件相关联。

Contoso使用传统的n层应用程序体系结构构建了PolicyConnect。数据访问层包含用于与基础SQL Server 2008 R2数据库进行交互的方法。业务逻辑层处理诸如用户登录和策略规则之类的事情。表示层提供用户界面（UI）。该设计遵循面向服务的体系结构，带有一系列Windows Communication Foundation（WCF）服务，这些服务代表了每个层所需的服务和功能。该应用程序将关联的策略文档作为PDF文件存储在可通过其局域网上的SMB网络共享访问的文件服务器上。PolicyConnect使用规范路径（客户的姓氏和策略编号）访问这些文件。SQL Server 2008 R2数据库包含每个策略文档的策略元数据，当前由Contoso工作人员手动输入到PolicyConnect中。Contoso提供了有关其当前拓扑的下图：

![The Contoso topology diagram has a local area network comprised of the on-premises user, Application servers for authentication and authorization, policy management and data access service, database servers, and file servers. A VPN server connects them to the Remote User via PolicyConnect.](media/image2.png "The Contoso topology diagram has a local area network comprised of the on-premise user, Application servers for authentication and authorization, policy management and data access service, database servers, and file servers. A VPN server connects them to the Remote User via PolicyConnect.")

该应用程序当前支持Contoso局域网以外的用户通过虚拟专用网络（VPN）连接进行访问。因此，除非被授予VPN访问权限，否则Contoso代理无法查看数据或文档。事实证明，此要求对于经纪人而言既耗时又令人沮丧。

Contoso员工将电子邮件作为与文档管理任务相关的工作流引擎。一个小组负责扫描和编目，而另一小组负责将策略分配给指定的代理。在扫描了客户的策略文档并将其编入索引之后，会将手动编写的电子邮件发送给经纪人。他们正在使用Office365。考虑到手动工作流程，公司高管在衡量生产率和吞吐量方面经常遇到挑战。他们感到自己无法快速获取所需的见解，因为每个新问题似乎都需要更多的自定义开发。

Contoso最近开始研究利用云来更新其保单持有人系统的方法，并开始解决现有PolicyConnect系统的若干问题。但是，他们缺乏任何有关云的实际经验，并且正在寻找有关如何最好地现代化和利用云技术的指南。

Contoso表示，他们的最高优先级是解决对SQL Server 2008 R2的支持终止。他们希望将其SQL Server 2008 R2数据库迁移到Azure中完全托管的SQL数据库。一旦数据库进入云中，他们便希望利用通过平台即服务（PaaS）数据库服务实现的一些主要优势。根据Contoso的说法，它不使用任何“高级” SQL Server功能，并希望迁移可以是平滑的。他们还希望更好地了解他们的数据库在Azure中运行后可能会利用的性能和安全性功能。

另一个首要任务是使该系统可以通过Web和移动应用程序供员工和经纪人使用，并且消除了建立VPN连接的需求。他们还希望将策略存储在云存储中，以通过这些Web和移动应用程序进行检索。Web和移动应用程序均应允许保单持有人登录，查看其信息并检索其保单的PDF副本。两个应用程序共享一个应用程序编程接口（API），可以访问数据和策略文档。目标是将Web应用程序，数据库和API部署到云中。此外，他们希望了解有关轻量级，无服务器架构的更多信息，这些架构可以帮助他们更快地实现某些API功能。他们提到了一个可能的用例，即提供对存储中策略文件的访问。

作为应用程序现代化过程的一部分，Contoso还希望了解更多有关Azure认知搜索可能如何提高其查找策略文档的能力的信息。PolicyConnect将所有策略文档以不透明PDF文件的形式存储在网络文件共享上，并且关键元数据会手动输入到PolicyConnect应用程序中。搜索仅限于文件名，并且手动输入了有限的元数据。目前，他们无法搜索政策文件中包含的信息。他们发现手动输入的元数据无法提供最佳结果，因为它们无法快速搜索和检索策略信息。

考虑到这些新应用程序可能会增加其数据库负载，他们希望采用最佳实践来减轻重复查询数据库的影响。沿着这些思路，他们希望实施一种记分板，以跟踪24小时内最活跃的用户，以及用户永久性地在系统内执行的大约操作次数。这两个指标都对管理很有吸引力，因为它可以粗略地了解谁是最重的用户以及他们使用系统的数量。

Contoso拥有多个开发团队，专注于不同的业务部门（例如，承销，销售，合规性和经纪人）。IT领导层很高兴将尽可能多的业务逻辑转移到API。但是，他们担心随着时间的推移，随着每个团队开发新的API或修改现有的API，可能会重复工作。他们还希望向关联合作伙伴网络开放一部分API。他们对有助于他们提供不断发展的API生态系统的可发现性，安全性和生命周期管理的策略感兴趣。他们希望对API使用情况进行高级分析和数据可视化，以帮助管理API库存。

根据Charlene Mathis的说法，“移动应用程序代表了将经纪人和员工带到他们手中的能力，从而使我们的经纪人和员工拥有能力。我们的主要投资是使PolicyConnect成为最佳移动应用程序版本。但是，我们也希望为我们的内部部门提供了一种简化的方法，可以快速构建自定义应用程序，以自动化省时的微流程，而无需我们的开发人员参与。” 她提到的一个微流程是使员工能够制定规则。例如，当VIP客户发送电子邮件时，他们会在其移动设备上收到应用程序通知。另一种情况是使员工能够设置工作流程，例如将带有策略文档的电子邮件中的附件自动保存到云存储中的适当位置。

通过此新系统，Contoso希望改善其安全实践。在以前的版本中，每个应用程序层都在本地维护其配置设置。例如，数据访问层将SQL Server的连接字符串本地存储在磁盘上。他们希望采用一种方法，将来自Web应用程序和API的秘密（例如，这些秘密）外部化，并将其存储在仅允许授权服务访问的加密位置。

Mathis说：“我们的创始人想要一个能够快速适应不断变化的业务需求同时又保持较低成本的文档系统。” “如果涉及的资源和IT支持最终使我们的增长减速，他们就不想在现场基础设施上进行投资。他们有一个明确的IT战略：'所有系统到云。'


### 客户需求

1. Contoso希望在保持基于.NET的同时对其解决方案的体系结构进行现代化。

2. 他们希望以.NET开发人员友好的方式来实现适用于Android和iOS的PolicyConnect移动应用程序.

3. 他们正在寻找方法来授权其业务用户创建内部移动应用程序，以帮助他们简化流程。他们希望添加此功能，而无需花费时间和资源来投入实施大型移动应用程序。.

4. 他们希望改善应用程序密钥的管理 .

5. 他们希望以最少的实施工作量就全文搜索政策文件.

6. 他们对利用无服务器技术来加速API开发感兴趣。他们要求提供概念证明（POC），可用于从存储中检索策略文档。

7. 他们希望将其SQL Server 2008 R2数据库迁移到Azure中完全托管的SQL数据库。进入Azure后，他们希望利用通过使用PaaS数据库服务启用的一些主要好处。

8. Contoso希望了解如何在其解决方案中部署更好的缓存，以减轻数据库的负担并提供可扩展的记分板。 

### 客户异议

1. 我们已经看到像IFTTT这样的服务（如果做到了，那么就做到了），使业务用户可以自动化流程。Microsoft Azure是否提供类似的功能？

2. 我们的开发人员听说过Logic Apps。Microsoft Flow会取代这些吗？

3. 有没有办法将应用程序秘密安全地存储在云中？

4. 我们注意到，Azure SQL数据库不支持SQL Server中的所有可用功能。我们目前不使用这些功能，但想知道Azure中这些功能的选项是什么？具体来说，我们正在考虑Linked Servers， Database Mail，SQL Server  Agent Jobs和Service Broker。 

5. 将所有内容转移到API听起来很棒，但是我们如何才能掌握API库存清单的顶部并管理可发现性，安全性，生命周期以及对未来的监视？有什么可以用来快速开发概念证明的东西吗？ 

6. 我们已经使用.NET Framework多年了，现在在Visual Studio Web中有.NET Framework，.NET Standard和.NET Core的选项。当我们着眼于创建新的Web和API应用程序时，我们如何选择正确的框架？

###  常见场景的信息图

![The Common scenario for an E-Commerce Website diagram has an Enterprise and an End User connected via an internet tier, a services tier, and a data tier.](media/image3.png "Common scenario for an E-Commerce Website diagram")

## 步骤 2: 设计一个概念验证解决方案

**目标**

设计一个解决方案，并准备以15分钟的对话形式将解决方案介绍给目标客户.

时间范围: 60 分钟

**业务要求**

方向: 让所有与会者都在您的餐桌旁，回答以下问题，并在活动挂图上列出答案：

1. 您应该向谁提出这个解决方案？谁是您的目标客户群？谁是决策者？

2. 您需要使用解决方案解决哪些客户业务需求？

**设计**

方向：让所有与会者都在您的圆桌旁，在活动挂图上回答以下问题：

_高层架构_

1. 在不涉及细节的情况下（以下几节将讨论特定的细节），您将初步了解如何处理移动和Web应用程序，数据管理，搜索和可扩展性的顶级需求。

_移动和网络应用_

1. Contoso应该如何实施PolicyConnect移动应用程序？

2. 哪些Azure服务将托管网站？

3. 哪些Azure服务将托管支持移动应用程序后端的服务？您会建议使用移动应用还是API应用？为什么？

4. 哪些Azure服务将提供轻量级，无服务器的API解决方案以从Azure blob存储中检索策略文档？

5. 您将如何保护网站和API使用的敏感信息？具体说明所使用的Azure服务，如何配置它以及Web或API逻辑如何在运行时检索其机密。

6. 您可以提出什么建议来帮助Contoso管理其API清单（随着将来的增长）？Azure中是否有现在可以提供概念证明API商店体验并可以作为将来开发之路的服务？

_数据管理_

1. 您会推荐Contoso使用哪些工具来迁移其数据库？您将如何使用这些？请明确点。

2. 您将使用什么模式和服务来减少数据库的负载？实施计分板？具体说明所使用的Azure服务以及应用程序将如何利用它们。

3. 根据他们的要求，您将如何对存储的策略文档启用全文搜索？

_搜索_

1. 如何使用Azure认知搜索从Contoso的策略文档中提取更多信息？

2. Contoso的开发人员是否可以扩展Azure认知搜索的功能，以包括内部开发的认知技能来丰富其搜索索引？

_可扩展性_

1. 您将如何使其业务用户创建自己的内部移动应用程序，以帮助他们简化流程，而无需花费时间和资源来投入实施大型移动应用程序？

2. 给定您对上一个问题的答案，Contoso业务用户将如何实现将高优先级电子邮件发送到其Office 365电子邮件并在其设备上显示应用程序通知的情况？

**准备**

方向: 让所有与会者都在您的圆桌旁:

1. 确定建议的解决方案未满足的任何客户需求.

2. 确定解决方案的好处.

3. 确定您将如何回应客户的疑义.

准备给客户15分钟的口头演讲风格的演示文稿.

## 第三步: 提出解决方案

**目标**

以15分钟的演讲形式向目标客户群体介绍解决方案.

时间范围: 30 分钟

**介绍**

目标:

1. 和另外一张桌子组队.

2. 一张桌子代表 Microsoft 团队和另外一张代表客户.

3. Microsoft团队向客户介绍了他们提出的解决方案

4. 客户从异议列表中提出一个异议.

5. Microsoft团队对此异议作出了回应。

6. 客户团队向Microsoft团队提供反馈。

7. 切换角色并重复步骤 2-6.

## 总结

时间范围: 15 分钟

Directions: 与较大的团体重新开会，以听取主持人/中小型企业分享研究案例的首选解决方案。.

## Additional references

|                                                       |                                                                                                    |
| ----------------------------------------------------- | -------------------------------------------------------------------------------------------------- |
| **Description**                                       | **Links**                                                                                          |
| Hi-resolution version of blueprint                    | <https://msdn.microsoft.com/dn630664#fbid=rVymR_3WSRo>                                             |
| Getting started with Xamarin and Mobile Apps          | <https://azure.microsoft.com/documentation/articles/app-service-mobile-xamarin-forms-get-started/> |
| Key Vault Developer's Guide                           | <https://azure.microsoft.com/documentation/articles/key-vault-developers-guide/>                   |
| About Keys and Secrets                                | <https://msdn.microsoft.com/library/dn903623.aspx>                                                 |
| Register an Application with AAD                      | <https://azure.microsoft.com/documentation/articles/key-vault-get-started/#register>               |
| How to Use Azure Redis Cache                          | <https://azure.microsoft.com/documentation/articles/cache-dotnet-how-to-use-azure-redis-cache/>    |
| Intro to Redis data types & abstractions              | <http://redis.io/topics/data-types-intro>                                                          |
| Intro to PowerApps                                    | <https://docs.microsoft.com/powerapps/getting-started>                                             |
| Get Started with Flow                                 | <https://flow.microsoft.com/documentation/getting-started/>                                        |
| Indexing Documents in Blob Storage                    | <https://azure.microsoft.com/documentation/articles/search-howto-indexing-azure-blob-storage/>     |
| Working with Azure Functions Proxies                  | <https://docs.microsoft.com/azure/azure-functions/functions-proxies>                               |
| Azure API Management Overview                         | <https://docs.microsoft.com/azure/api-management/api-management-key-concepts>                      |
| What is "cognitive search" in Azure Cognitive Search? | <https://docs.microsoft.com/azure/search/cognitive-search-concept-intro>                           |
