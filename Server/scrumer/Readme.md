* DB Specification
** All db object name should be uppercse.
** If object name contains more than one word, use underline to concat them.

* Code Specification
** Build no warning, warning means potential **bugs**.
** PO : Persistent object.  One table one PO.

** VO: View object, used for client to display or receive client's data. 
**# The name must ends with VO, and must extends from BaseVO.


** Service: Support service for others. handle core business here.
**# All must have a interface.
**# Name must ends with Service.
**# Interact with PO.


*8 Controller: Handle request from client. Can interact with service and VO.
**# Name must ends with Controller

** Enum must start with Enum , name format: Enum + TableName + TableColumnName
