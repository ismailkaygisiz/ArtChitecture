// This file has been generated by the reflectable package.
// https://github.com/dart-lang/reflectable.
// @dart = 2.12

import 'dart:core';
import 'package:flutter_ui/core/models/entity.dart' as prefix0;
import 'package:flutter_ui/core/models/language/language_model.dart' as prefix1;
import 'package:flutter_ui/core/models/operationClaim/operation_claim_model.dart'
    as prefix3;
import 'package:flutter_ui/core/models/translate/translate_model.dart'
    as prefix2;
import 'package:flutter_ui/core/models/user/login_model.dart' as prefix8;
import 'package:flutter_ui/core/models/user/refresh_token_model.dart'
    as prefix9;
import 'package:flutter_ui/core/models/user/register_model.dart' as prefix6;
import 'package:flutter_ui/core/models/user/token_model.dart' as prefix7;
import 'package:flutter_ui/core/models/user/user_model.dart' as prefix5;
import 'package:flutter_ui/core/models/userOperationClaim/user_operation_claim_model.dart'
    as prefix4;

// ignore_for_file: prefer_adjacent_string_concatenation
// ignore_for_file: prefer_collection_literals
// ignore_for_file: unnecessary_const
// ignore_for_file: implementation_imports

// ignore:unused_import
import 'package:reflectable/mirrors.dart' as m;
// ignore:unused_import
import 'package:reflectable/src/reflectable_builder_based.dart' as r;
// ignore:unused_import
import 'package:reflectable/reflectable.dart' as r show Reflectable;

final _data = <r.Reflectable, r.ReflectorData>{
  const prefix0.Entity(): r.ReflectorData(
      <m.TypeMirror>[
        r.NonGenericClassMirrorImpl(
            r'LanguageModel',
            r'.LanguageModel',
            7,
            0,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (id, languageCode, languageName) => b
                  ? prefix1.LanguageModel(id, languageCode, languageName)
                  : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix1.LanguageModel.fromJson(json) : null
            },
            -1,
            -1,
            const <int>[-1],
            null,
            {
              r'==': 1,
              r'toString': 0,
              r'noSuchMethod': 1,
              r'hashCode': 0,
              r'runtimeType': 0,
              r'toJson': 0,
              r'id': 0,
              r'id=': 1,
              r'languageCode': 0,
              r'languageCode=': 1,
              r'languageName': 0,
              r'languageName=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'TranslateModel',
            r'.TranslateModel',
            7,
            1,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (id, languageId, key, value) =>
                  b ? prefix2.TranslateModel(id, languageId, key, value) : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix2.TranslateModel.fromJson(json) : null
            },
            -1,
            -1,
            const <int>[-1],
            null,
            {
              r'==': 1,
              r'toString': 0,
              r'noSuchMethod': 1,
              r'hashCode': 0,
              r'runtimeType': 0,
              r'toJson': 0,
              r'id': 0,
              r'id=': 1,
              r'languageId': 0,
              r'languageId=': 1,
              r'key': 0,
              r'key=': 1,
              r'value': 0,
              r'value=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'OperationClaimModel',
            r'.OperationClaimModel',
            7,
            2,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (id, name) =>
                  b ? prefix3.OperationClaimModel(id, name) : null,
              r'fromJson': (bool b) => (json) =>
                  b ? prefix3.OperationClaimModel.fromJson(json) : null
            },
            -1,
            -1,
            const <int>[-1],
            null,
            {
              r'==': 1,
              r'toString': 0,
              r'noSuchMethod': 1,
              r'hashCode': 0,
              r'runtimeType': 0,
              r'toJson': 0,
              r'id': 0,
              r'id=': 1,
              r'name': 0,
              r'name=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'UserOperationClaimModel',
            r'.UserOperationClaimModel',
            7,
            3,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (id, userId, claimId) => b
                  ? prefix4.UserOperationClaimModel(id, userId, claimId)
                  : null,
              r'fromJson': (bool b) => (json) =>
                  b ? prefix4.UserOperationClaimModel.fromJson(json) : null
            },
            -1,
            -1,
            const <int>[-1],
            null,
            {
              r'==': 1,
              r'toString': 0,
              r'noSuchMethod': 1,
              r'hashCode': 0,
              r'runtimeType': 0,
              r'toJson': 0,
              r'id': 0,
              r'id=': 1,
              r'userId': 0,
              r'userId=': 1,
              r'claimId': 0,
              r'claimId=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'UserModel',
            r'.UserModel',
            7,
            4,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (id, email, status) =>
                  b ? prefix5.UserModel(id, email, status) : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix5.UserModel.fromJson(json) : null
            },
            -1,
            -1,
            const <int>[-1],
            null,
            {
              r'==': 1,
              r'toString': 0,
              r'noSuchMethod': 1,
              r'hashCode': 0,
              r'runtimeType': 0,
              r'toJson': 0,
              r'id': 0,
              r'id=': 1,
              r'email': 0,
              r'email=': 1,
              r'status': 0,
              r'status=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'RegisterModel',
            r'.RegisterModel',
            7,
            5,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (email, password) =>
                  b ? prefix6.RegisterModel(email, password) : null
            },
            -1,
            -1,
            const <int>[-1],
            null,
            {
              r'==': 1,
              r'toString': 0,
              r'noSuchMethod': 1,
              r'hashCode': 0,
              r'runtimeType': 0,
              r'toJson': 0,
              r'email': 0,
              r'email=': 1,
              r'password': 0,
              r'password=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'TokenModel',
            r'.TokenModel',
            7,
            6,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (token, expiration, refreshToken) => b
                  ? prefix7.TokenModel(token, expiration, refreshToken)
                  : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix7.TokenModel.fromJson(json) : null
            },
            -1,
            -1,
            const <int>[-1],
            null,
            {
              r'==': 1,
              r'toString': 0,
              r'noSuchMethod': 1,
              r'hashCode': 0,
              r'runtimeType': 0,
              r'token': 0,
              r'token=': 1,
              r'expiration': 0,
              r'expiration=': 1,
              r'refreshToken': 0,
              r'refreshToken=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'LoginModel',
            r'.LoginModel',
            7,
            7,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (email, password) =>
                  b ? prefix8.LoginModel(email, password) : null
            },
            -1,
            -1,
            const <int>[-1],
            null,
            {
              r'==': 1,
              r'toString': 0,
              r'noSuchMethod': 1,
              r'hashCode': 0,
              r'runtimeType': 0,
              r'toJson': 0,
              r'email': 0,
              r'email=': 1,
              r'password': 0,
              r'password=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'RefreshTokenModel',
            r'.RefreshTokenModel',
            7,
            8,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (refreshTokenValue, refreshTokenEndDate,
                      clientId, clientName) =>
                  b
                      ? prefix9.RefreshTokenModel(refreshTokenValue,
                          refreshTokenEndDate, clientId, clientName)
                      : null,
              r'withJson': (bool b) => (refreshTokenId,
                      userId,
                      clientId,
                      clientName,
                      tokenValue,
                      refreshTokenValue,
                      refreshTokenEndDate,
                      jsonData) =>
                  b
                      ? prefix9.RefreshTokenModel.withJson(
                          refreshTokenId,
                          userId,
                          clientId,
                          clientName,
                          tokenValue,
                          refreshTokenValue,
                          refreshTokenEndDate,
                          jsonData)
                      : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix9.RefreshTokenModel.fromJson(json) : null
            },
            -1,
            -1,
            const <int>[-1],
            null,
            {
              r'==': 1,
              r'toString': 0,
              r'noSuchMethod': 1,
              r'hashCode': 0,
              r'runtimeType': 0,
              r'refreshTokenId': 0,
              r'refreshTokenId=': 1,
              r'userId': 0,
              r'userId=': 1,
              r'clientId': 0,
              r'clientId=': 1,
              r'clientName': 0,
              r'clientName=': 1,
              r'tokenValue': 0,
              r'tokenValue=': 1,
              r'refreshTokenValue': 0,
              r'refreshTokenValue=': 1,
              r'refreshTokenEndDate': 0,
              r'refreshTokenEndDate=': 1,
              r'jsonData': 0,
              r'jsonData=': 1
            })
      ],
      null,
      null,
      <Type>[
        prefix1.LanguageModel,
        prefix2.TranslateModel,
        prefix3.OperationClaimModel,
        prefix4.UserOperationClaimModel,
        prefix5.UserModel,
        prefix6.RegisterModel,
        prefix7.TokenModel,
        prefix8.LoginModel,
        prefix9.RefreshTokenModel
      ],
      9,
      {
        r'==': (dynamic instance) => (x) => instance == x,
        r'toString': (dynamic instance) => instance.toString,
        r'noSuchMethod': (dynamic instance) => instance.noSuchMethod,
        r'hashCode': (dynamic instance) => instance.hashCode,
        r'runtimeType': (dynamic instance) => instance.runtimeType,
        r'toJson': (dynamic instance) => instance.toJson,
        r'id': (dynamic instance) => instance.id,
        r'languageCode': (dynamic instance) => instance.languageCode,
        r'languageName': (dynamic instance) => instance.languageName,
        r'languageId': (dynamic instance) => instance.languageId,
        r'key': (dynamic instance) => instance.key,
        r'value': (dynamic instance) => instance.value,
        r'name': (dynamic instance) => instance.name,
        r'userId': (dynamic instance) => instance.userId,
        r'claimId': (dynamic instance) => instance.claimId,
        r'email': (dynamic instance) => instance.email,
        r'status': (dynamic instance) => instance.status,
        r'password': (dynamic instance) => instance.password,
        r'token': (dynamic instance) => instance.token,
        r'expiration': (dynamic instance) => instance.expiration,
        r'refreshToken': (dynamic instance) => instance.refreshToken,
        r'refreshTokenId': (dynamic instance) => instance.refreshTokenId,
        r'clientId': (dynamic instance) => instance.clientId,
        r'clientName': (dynamic instance) => instance.clientName,
        r'tokenValue': (dynamic instance) => instance.tokenValue,
        r'refreshTokenValue': (dynamic instance) => instance.refreshTokenValue,
        r'refreshTokenEndDate': (dynamic instance) =>
            instance.refreshTokenEndDate,
        r'jsonData': (dynamic instance) => instance.jsonData
      },
      {
        r'id=': (dynamic instance, value) => instance.id = value,
        r'languageCode=': (dynamic instance, value) =>
            instance.languageCode = value,
        r'languageName=': (dynamic instance, value) =>
            instance.languageName = value,
        r'languageId=': (dynamic instance, value) =>
            instance.languageId = value,
        r'key=': (dynamic instance, value) => instance.key = value,
        r'value=': (dynamic instance, value) => instance.value = value,
        r'name=': (dynamic instance, value) => instance.name = value,
        r'userId=': (dynamic instance, value) => instance.userId = value,
        r'claimId=': (dynamic instance, value) => instance.claimId = value,
        r'email=': (dynamic instance, value) => instance.email = value,
        r'status=': (dynamic instance, value) => instance.status = value,
        r'password=': (dynamic instance, value) => instance.password = value,
        r'token=': (dynamic instance, value) => instance.token = value,
        r'expiration=': (dynamic instance, value) =>
            instance.expiration = value,
        r'refreshToken=': (dynamic instance, value) =>
            instance.refreshToken = value,
        r'refreshTokenId=': (dynamic instance, value) =>
            instance.refreshTokenId = value,
        r'clientId=': (dynamic instance, value) => instance.clientId = value,
        r'clientName=': (dynamic instance, value) =>
            instance.clientName = value,
        r'tokenValue=': (dynamic instance, value) =>
            instance.tokenValue = value,
        r'refreshTokenValue=': (dynamic instance, value) =>
            instance.refreshTokenValue = value,
        r'refreshTokenEndDate=': (dynamic instance, value) =>
            instance.refreshTokenEndDate = value,
        r'jsonData=': (dynamic instance, value) => instance.jsonData = value
      },
      null,
      [
        const [0, 0, null],
        const [1, 0, null],
        const [3, 0, null],
        const [4, 0, null],
        const [2, 0, null],
        const [8, 0, null]
      ])
};

final _memberSymbolMap = null;

void initializeReflectable() {
  r.data = _data;
  r.memberSymbolMap = _memberSymbolMap;
}
