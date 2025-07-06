import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJUYXNrSHViLkFwaSIsImF1ZCI6IlRhc2tIdWIuQ2xpZW50In0.u3a0TQmdZWEx2QE3KB5QUFHQXTbk7_x3xu_B5Zx9yJE"; // todo auth service

  if (token) {
    const authReq = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
    return next(authReq);
  }

  return next(req);
};
