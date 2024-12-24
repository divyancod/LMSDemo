import { TestBed } from '@angular/core/testing';

import { AuthCallInterceptor } from './auth-call.interceptor';

describe('AuthCallInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      AuthCallInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: AuthCallInterceptor = TestBed.inject(AuthCallInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
