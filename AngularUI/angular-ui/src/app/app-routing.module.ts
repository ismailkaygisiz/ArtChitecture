import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// guards
import { LoginDisableGuard } from './core/guards/login-disable.guard';
import { LoginGuard } from './core/guards/login.guard';
import { AdminGuard } from './core/guards/admin.guard';

// layouts
import { AdminLayoutComponent } from './core/layouts/admin-layout/admin-layout.component';
import { AuthLayoutComponent } from './core/layouts/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './core/layouts/main-layout/main-layout.component';

// error
import { ErrorComponent } from './core/components/error/error.component';

// admin
import { DashboardComponent } from './core/components/admin/dashboard/dashboard.component';

// auth
import { AuthComponent } from './core/components/auth/auth/auth.component';
import { LoginComponent } from './core/components/auth/login/login.component';
import { RegisterComponent } from './core/components/auth/register/register.component';

// main


const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [],
  },
  {
    path: 'admin',
    component: AdminLayoutComponent,
    canActivate: [AdminGuard],
    children: [
      { path: '', component: DashboardComponent }
    ],
  },
  {
    path: 'auth',
    component: AuthLayoutComponent,
    children: [
      { path: '', component: AuthComponent },
      { path: 'login', component: LoginComponent, canActivate: [LoginDisableGuard] },
      { path: 'register', component: RegisterComponent, canActivate: [LoginDisableGuard] },
    ],
  },
  {
    path: '**',
    component: ErrorComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
