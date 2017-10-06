import { Platform.Client.WebClient.FrontendPage } from './app.po';

describe('platform.client.web-client.frontend App', () => {
  let page: Platform.Client.WebClient.FrontendPage;

  beforeEach(() => {
    page = new Platform.Client.WebClient.FrontendPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
