namespace NovelWebsite.Application.Utils
{
    public static class EmailTemplate
    {

        public static string GenerateEmailTemplate(string name, string url)
        {
            return $@"<tbody><tr>
        <td style=""font-family: sans-serif; font-size: 14px; vertical-align: top;"">&nbsp;</td>
        <td class=""container"" style=""font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; margin: 0 auto; max-width: 580px; padding: 10px; width: 580px;"">
          <div class=""content"" style=""box-sizing: border-box; display: block; margin: 0 auto; max-width: 580px; padding: 10px;"">
            <span class=""preheader"" style=""color: transparent; display: none; height: 0; max-height: 0; max-width: 0; opacity: 0; overflow: hidden; mso-hide: all; visibility: hidden; width: 0;"">This is preheader text. Some clients will show this text as a preview.</span>
            <table class=""main"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #ffffff; border-radius: 3px;"">
              <tbody><tr>
                <td class=""wrapper"" style=""font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 20px;"">
                  <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;"">
                    <tbody><tr>
                      <td style=""font-family: sans-serif; font-size: 14px; vertical-align: top;"">
                        <p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;"">Xin chào {name},</p>
                        <p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;"">Để hoàn thành việc tạo tài khoản tại Novel Website, xin hãy xác minh tài khoản của bạn bằng cách nhấn vào nút dưới đây</p>
                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""btn btn-primary"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; box-sizing: border-box;"">
                          <tbody>
                            <tr>
                              <td align=""left"" style=""font-family: sans-serif; font-size: 14px; vertical-align: top; padding-bottom: 15px;"">
                                <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: auto;"">
                                  <tbody>
                                    <tr>
                                      <td style=""font-family: sans-serif; font-size: 14px; vertical-align: top; background-color: #3498db; border-radius: 5px; text-align: center;""> <a href=""{url}""  style=""display: inline-block; color: #ffffff; background-color: #3498db; border: solid 1px #3498db; border-radius: 5px; box-sizing: border-box; cursor: pointer; text-decoration: none; font-size: 14px; font-weight: bold; margin: 0; padding: 12px 25px; text-transform: capitalize; border-color: #3498db;"">Xác minh tài khoản</a> </td>
                                    </tr>
                                  </tbody>
                                </table>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                        <p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;"">Nếu bạn gặp vấn đề gì, xin hãy liên hệ với tài khoản hỗ trợ của chúng tôi support@novelwebsite.com</p>
                        <p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;"">Cảm ơn vì đã đăng ký tài khoản, chúc bạn một ngày vui vẻ!</p>
                      <p style=""font-family: sans-serif; font-size: 14px; font-weight: bold; margin: 0; margin-bottom: 15px;"">Team Novel Website</p></td>
                    </tr>
                  </tbody></table>
                </td>
              </tr>

            <!-- END MAIN CONTENT AREA -->
            </tbody></table>

            <!-- START FOOTER -->
            <div class=""footer"" style=""clear: both; margin-top: 10px; text-align: center; width: 100%;"">
              <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;"">
                <tbody><tr>
                  <td class=""content-block"" style=""font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;"">
                    <span class=""apple-link"" style=""color: #999999; font-size: 12px; text-align: center;"">Company Inc, 3 Abbey Road, San Francisco CA 94102</span>
                    <br> Don't like these emails? <a href=""http://i.imgur.com/CScmqnj.gif"" style=""text-decoration: underline; color: #999999; font-size: 12px; text-align: center;"">Unsubscribe</a>.
                  </td>
                </tr>
                <tr>
                  <td class=""content-block powered-by"" style=""font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;"">
                    Powered by <a href=""http://htmlemail.io"" style=""color: #999999; font-size: 12px; text-align: center; text-decoration: none;"">HTMLemail</a>.
                  </td>
                </tr>
              </tbody></table>
            </div>
            <!-- END FOOTER -->

          <!-- END CENTERED WHITE CONTAINER -->
          </div>
        </td>
        <td style=""font-family: sans-serif; font-size: 14px; vertical-align: top;"">&nbsp;</td>
      </tr>
    </tbody>";
        }
    }
}
