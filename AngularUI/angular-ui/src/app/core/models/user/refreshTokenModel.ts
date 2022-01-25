export interface RefreshTokenModel {
  refreshTokenId: number;
  userId: number;
  refreshTokenValue: string;
  refreshTokenEndDate: Date;
  clientId: string;
  clientName: string;
}
