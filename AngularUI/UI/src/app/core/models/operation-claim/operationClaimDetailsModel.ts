import { OperationClaimModel } from './operationClaimModel';

export interface OperationClaimDetailsModel {
  id: number;
  claims: OperationClaimModel[];
  firstName: string;
  lastName: string;
  email: string;
}
