import 'package:flutter_ui/core/interceptors/http_client.dart';
import 'package:flutter_ui/core/services/auth_service.dart';
import 'package:flutter_ui/core/services/language_service.dart';
import 'package:flutter_ui/core/services/operation_claim_service.dart';
import 'package:flutter_ui/core/services/signalr_service.dart';
import 'package:flutter_ui/core/services/storage_service.dart';
import 'package:flutter_ui/core/services/token_service.dart';
import 'package:flutter_ui/core/services/translate_service.dart';
import 'package:flutter_ui/core/services/user_operation_claim_service.dart';
import 'package:flutter_ui/core/services/user_service.dart';
import 'package:flutter_ui/services/validation_service.dart';

final HttpClient httpClient = HttpClient();
final AuthService authService = AuthService();
final LanguageService languageService = LanguageService();
final OperationClaimService operationClaimService = OperationClaimService();
final StorageService storageService = StorageService();
final SignalRService signalRService = SignalRService();
final TokenService tokenService = TokenService();
final TranslateService translateService = TranslateService();
final UserOperationClaimService userOperationClaimService =
    UserOperationClaimService();
final UserService userService = UserService();
final ValidationService validationService = ValidationService();
