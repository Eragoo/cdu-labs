<%--
  Created by IntelliJ IDEA.
  User: ykukhol
  Date: 23.05.21
  Time: 10:02
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<html>
  <head>
    <title>$Title$</title>
  </head>
  <body>
  <form action="" method="post">
  <table style="width:100%">
    <tr>
      <th>Id</th>
      <th>Name</th>
      <th>Description</th>
      <th>Action</th>
    </tr>
    <tr>
      <th></th>
      <th><input type="text" id="name" name="name" required minlength="4" maxlength="8" size="10"></th>
      <th><input type="text" id="desc" name="desc" required minlength="4" maxlength="8" size="10"></th>
      <th><input type="submit"value="Add"/></th>
    </tr>
    <c:forEach var="wood" items="${dir}">
      <tr>
        <th><p>${wood.id}</p></th>
        <th><p>${wood.name}</p></th>
        <th><p>${wood.description}</p></th>
      </tr>
    </c:forEach>
    <tr>
  </table>
  </form>
  </body>
</html>
