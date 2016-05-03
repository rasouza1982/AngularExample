<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" ng-controller="employeeCtrl" ng-app="app">
        <table class="table table-striped table-hover table-condensed">
            <thead>
                <th>Id</th>
                <th>Nome</th>
                <th>Matrícula</th>
                <th>Departamento</th>
            </thead>
            <tbody>
                <tr ng-repeat="employee in employees">
                    <td>{{employee.id}}</td>
                    <td>{{employee.name}}</td>
                    <td>{{employee.matricula}}</td>
                    <td>{{employee.department}}</td>
                </tr>                

            </tbody>

        </table>

        <br />

           <table class="table table-striped table-hover table-condensed">
            <thead>
                <th>Id</th>
                <th>Departamento</th>
            </thead>
            <tbody>
                <tr ng-repeat="department in departments">
                    <td>{{department.id}}</td>
                    <td>{{department.name}}</td>
                </tr>                

            </tbody>

        </table>

    </div>
</asp:Content>
