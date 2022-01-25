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
    children: [],
  },
  {
    path: 'auth',
    component: AuthLayoutComponent,
    children: [],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
