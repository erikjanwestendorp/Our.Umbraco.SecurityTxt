﻿using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.SecurityTxt.Models;
using Our.Umbraco.SecurityTxt.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.SecurityTxt.Controllers;

[PluginController("SecurityTxt")]
public class SecurityTxtController : UmbracoAuthorizedApiController
{
    private readonly ISecurityTxtService _securityTxtService;
    public SecurityTxtController(ISecurityTxtService securityTxtService)
    {
        _securityTxtService = securityTxtService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(_securityTxtService.GetContent());
    }

    [HttpPost]
    public IActionResult Save(SecurityTxtModel model)
    {
        if (!string.IsNullOrWhiteSpace(model.Content))
        {
            _securityTxtService.SetContent(model.Content);
        }
        return Get();
    }
}
