import { Platform.Client.WebClientPage } from './app.po';

describe('platform.client.web-client App', () => {
  let page: Platform.Client.WebClientPage;

  beforeEach(() => {
    page = new Platform.Client.WebClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
