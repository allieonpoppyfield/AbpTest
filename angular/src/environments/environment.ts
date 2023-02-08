import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'AbpTest',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44326/',
    redirectUri: baseUrl,
    clientId: 'AbpTest_App',
    responseType: 'code',
    scope: 'offline_access AbpTest',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44326',
      rootNamespace: 'AbpTest',
    },
  },
} as Environment;
