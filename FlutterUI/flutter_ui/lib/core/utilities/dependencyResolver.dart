import 'package:flutter_ui/core/services/authService.dart';
import 'package:flutter_ui/core/services/cryptoService.dart';
import 'package:flutter_ui/core/services/languageService.dart';
import 'package:flutter_ui/core/services/operationClaimService.dart';
import 'package:flutter_ui/core/services/sessionService.dart';
import 'package:flutter_ui/core/services/signalRService.dart';
import 'package:flutter_ui/core/services/tokenService.dart';
import 'package:flutter_ui/core/services/translateService.dart';
import 'package:flutter_ui/core/services/userOperationClaimService.dart';
import 'package:flutter_ui/core/services/userService.dart';
import 'package:flutter_ui/core/services/validationService.dart';

final AuthService authService = AuthService();
final CryptoService cryptoService = CryptoService();
final LanguageService languageService = LanguageService();
final OperationClaimService operationClaimService = OperationClaimService();
final SessionService sessionService = SessionService();
final SignalRService signalRService = SignalRService();
final TokenService tokenService = TokenService();
final TranslateService translateService = TranslateService();
final UserOperationClaimService userOperationClaimService =
    UserOperationClaimService();
final UserService userService = UserService();
final ValidationService validationService = ValidationService();
