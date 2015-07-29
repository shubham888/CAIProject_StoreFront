<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 34px;
        }
        .auto-style3 {
            height: 39px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Master_CPHolder" Runat="Server">
    <table style="color:black; height: 0px; width: 100%;">
        <thead style="width:100%">
            <tr>
                <td colspan="2" style="text-align:center;height:50px;grid-row-span:2;background-color:gray"><h1 style="color:black">Random Content</h1></td>
            </tr>
        </thead>
        <tr style="column-span:all;text-align:center;">
            <td colspan="2" style="height:50px;background-color:darkgray">
                <h1 style="color:black">Random Content 2</h1>
            </td>
        </tr>
        <tr style="background-color:lightgray; height:300px">
            <td style="text-align:center">
                Random Content 3
            </td>
            <td style="text-align:center">
                Random Content 4
            </td>
        </tr>

    </table>
</asp:Content>

