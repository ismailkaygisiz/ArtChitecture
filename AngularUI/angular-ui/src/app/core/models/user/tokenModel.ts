import { RefreshTokenModel } from './refreshTokenModel';

export interface TokenModel {
  token: string;
  expiration: string;
  refreshToken: RefreshTokenModel;
}
