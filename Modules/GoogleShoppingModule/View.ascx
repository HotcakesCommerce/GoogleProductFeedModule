<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Hotcakes.Modules.GoogleShoppingModule.View" %>
<div class="dnnClear">
    <h2><%=GetLocalizedString("GoogleFeedHeader") %></h2>
    <p><%=GetLocalizedString("GoogleProductFeedDesc") %></p>
    <p><asp:button id="btnBuildGoogleFeed" runat="server" CssClass="dnnPrimaryAction" onclick="btnBuildGoogleFeed_OnClick"/></p>
</div>
<div class="dnnClear">
    <h3><%=GetLocalizedString("GoogleFeedTitle") %></h3>
    <p><%=GetLocalizedString("FeedInstruction") %></p>
    <p><asp:textbox id="txtGoogleFeed" runat="server" Rows="30" TextMode="MultiLine" Width="100%"/></p>
</div>