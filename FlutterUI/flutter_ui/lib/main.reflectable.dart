// This file has been generated by the reflectable package.
// https://github.com/dart-lang/reflectable.
// @dart = 2.9

import 'dart:core';
import 'package:flutter_ui/core/models/entity.dart' as prefix0;
import 'package:flutter_ui/core/models/language/languageAddModel.dart'
    as prefix10;
import 'package:flutter_ui/core/models/language/languageModel.dart' as prefix9;
import 'package:flutter_ui/core/models/operationClaim/operationClaimAddModel.dart'
    as prefix12;
import 'package:flutter_ui/core/models/operationClaim/operationClaimDetailsModel.dart'
    as prefix13;
import 'package:flutter_ui/core/models/operationClaim/operationClaimModel.dart'
    as prefix11;
import 'package:flutter_ui/core/models/translate/translateAddModel.dart'
    as prefix2;
import 'package:flutter_ui/core/models/translate/translateModel.dart'
    as prefix3;
import 'package:flutter_ui/core/models/user/loginModel.dart' as prefix1;
import 'package:flutter_ui/core/models/user/refreshTokenModel.dart' as prefix6;
import 'package:flutter_ui/core/models/user/registerModel.dart' as prefix5;
import 'package:flutter_ui/core/models/user/tokenModel.dart' as prefix4;
import 'package:flutter_ui/core/models/user/userAddModel.dart' as prefix15;
import 'package:flutter_ui/core/models/user/userModel.dart' as prefix14;
import 'package:flutter_ui/core/models/userOperationClaim/userOperationClaimAddModel.dart'
    as prefix8;
import 'package:flutter_ui/core/models/userOperationClaim/userOperationClaimModel.dart'
    as prefix7;

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
            r'LoginModel',
            r'.LoginModel',
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
              r'': (bool b) => (email, password) =>
                  b ? prefix1.LoginModel(email, password) : null
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
            r'TranslateAddModel',
            r'.TranslateAddModel',
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
              r'': (bool b) => (languageId, key, value) =>
                  b ? prefix2.TranslateAddModel(languageId, key, value) : null
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
              r'languageId': 0,
              r'languageId=': 1,
              r'key': 0,
              r'key=': 1,
              r'value': 0,
              r'value=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'TranslateModel',
            r'.TranslateModel',
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
              r'': (bool b) => (id, languageId, key, value) =>
                  b ? prefix3.TranslateModel(id, languageId, key, value) : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix3.TranslateModel.fromJson(json) : null
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
            r'TokenModel',
            r'.TokenModel',
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
              r'': (bool b) => (token, expiration, refreshToken) => b
                  ? prefix4.TokenModel(token, expiration, refreshToken)
                  : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix4.TokenModel.fromJson(json) : null
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
            r'RegisterModel',
            r'.RegisterModel',
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
              r'': (bool b) => (firstName, lastName, email, password) => b
                  ? prefix5.RegisterModel(firstName, lastName, email, password)
                  : null
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
              r'firstName': 0,
              r'firstName=': 1,
              r'lastName': 0,
              r'lastName=': 1,
              r'email': 0,
              r'email=': 1,
              r'password': 0,
              r'password=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'RefreshTokenModel',
            r'.RefreshTokenModel',
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
              r'': (bool b) => (refreshTokenValue, refreshTokenEndDate,
                      clientId, clientName) =>
                  b
                      ? prefix6.RefreshTokenModel(refreshTokenValue,
                          refreshTokenEndDate, clientId, clientName)
                      : null,
              r'withJson': (bool b) => (refreshTokenValue, refreshTokenEndDate,
                      clientId, clientName, jsonData) =>
                  b
                      ? prefix6.RefreshTokenModel.withJson(refreshTokenValue,
                          refreshTokenEndDate, clientId, clientName, jsonData)
                      : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix6.RefreshTokenModel.fromJson(json) : null
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
              r'refreshTokenValue': 0,
              r'refreshTokenValue=': 1,
              r'refreshTokenEndDate': 0,
              r'refreshTokenEndDate=': 1,
              r'clientId': 0,
              r'clientId=': 1,
              r'clientName': 0,
              r'clientName=': 1,
              r'jsonData': 0,
              r'jsonData=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'UserOperationClaimModel',
            r'.UserOperationClaimModel',
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
              r'': (bool b) => (id, userId, claimId) => b
                  ? prefix7.UserOperationClaimModel(id, userId, claimId)
                  : null,
              r'fromJson': (bool b) => (json) =>
                  b ? prefix7.UserOperationClaimModel.fromJson(json) : null
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
            r'UserOperationClaimAddModel',
            r'.UserOperationClaimAddModel',
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
              r'': (bool b) => (userId, claimId) =>
                  b ? prefix8.UserOperationClaimAddModel(userId, claimId) : null
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
              r'userId': 0,
              r'userId=': 1,
              r'claimId': 0,
              r'claimId=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'LanguageModel',
            r'.LanguageModel',
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
              r'': (bool b) => (id, languageCode, languageName) => b
                  ? prefix9.LanguageModel(id, languageCode, languageName)
                  : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix9.LanguageModel.fromJson(json) : null
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
            r'LanguageAddModel',
            r'.LanguageAddModel',
            7,
            9,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (languageCode, languageName) => b
                  ? prefix10.LanguageAddModel(languageCode, languageName)
                  : null
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
              r'languageCode': 0,
              r'languageCode=': 1,
              r'languageName': 0,
              r'languageName=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'OperationClaimModel',
            r'.OperationClaimModel',
            7,
            10,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (id, name) =>
                  b ? prefix11.OperationClaimModel(id, name) : null,
              r'fromJson': (bool b) => (json) =>
                  b ? prefix11.OperationClaimModel.fromJson(json) : null
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
            r'OperationClaimAddModel',
            r'.OperationClaimAddModel',
            7,
            11,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) =>
                  (name) => b ? prefix12.OperationClaimAddModel(name) : null
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
              r'name': 0,
              r'name=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'OperationClaimDetailsModel',
            r'.OperationClaimDetailsModel',
            7,
            12,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (id, claims, firstName, lastName, email) => b
                  ? prefix13.OperationClaimDetailsModel(
                      id, claims, firstName, lastName, email)
                  : null,
              r'fromJson': (bool b) => (json) =>
                  b ? prefix13.OperationClaimDetailsModel.fromJson(json) : null
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
              r'id': 0,
              r'id=': 1,
              r'claims': 0,
              r'claims=': 1,
              r'firstName': 0,
              r'firstName=': 1,
              r'lastName': 0,
              r'lastName=': 1,
              r'email': 0,
              r'email=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'UserModel',
            r'.UserModel',
            7,
            13,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (id, firstName, lastName, email, status) => b
                  ? prefix14.UserModel(id, firstName, lastName, email, status)
                  : null,
              r'fromJson': (bool b) =>
                  (json) => b ? prefix14.UserModel.fromJson(json) : null
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
              r'firstName': 0,
              r'firstName=': 1,
              r'lastName': 0,
              r'lastName=': 1,
              r'email': 0,
              r'email=': 1,
              r'status': 0,
              r'status=': 1
            }),
        r.NonGenericClassMirrorImpl(
            r'UserAddModel',
            r'.UserAddModel',
            7,
            14,
            const prefix0.Entity(),
            const <int>[-1],
            null,
            null,
            -1,
            {},
            {},
            {
              r'': (bool b) => (firstName, lastName, email, status) => b
                  ? prefix15.UserAddModel(firstName, lastName, email, status)
                  : null
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
              r'firstName': 0,
              r'firstName=': 1,
              r'lastName': 0,
              r'lastName=': 1,
              r'email': 0,
              r'email=': 1,
              r'status': 0,
              r'status=': 1
            })
      ],
      null,
      null,
      <Type>[
        prefix1.LoginModel,
        prefix2.TranslateAddModel,
        prefix3.TranslateModel,
        prefix4.TokenModel,
        prefix5.RegisterModel,
        prefix6.RefreshTokenModel,
        prefix7.UserOperationClaimModel,
        prefix8.UserOperationClaimAddModel,
        prefix9.LanguageModel,
        prefix10.LanguageAddModel,
        prefix11.OperationClaimModel,
        prefix12.OperationClaimAddModel,
        prefix13.OperationClaimDetailsModel,
        prefix14.UserModel,
        prefix15.UserAddModel
      ],
      15,
      {
        r'==': (dynamic instance) => (x) => instance == x,
        r'toString': (dynamic instance) => instance.toString,
        r'noSuchMethod': (dynamic instance) => instance.noSuchMethod,
        r'hashCode': (dynamic instance) => instance.hashCode,
        r'runtimeType': (dynamic instance) => instance.runtimeType,
        r'toJson': (dynamic instance) => instance.toJson,
        r'email': (dynamic instance) => instance.email,
        r'password': (dynamic instance) => instance.password,
        r'languageId': (dynamic instance) => instance.languageId,
        r'key': (dynamic instance) => instance.key,
        r'value': (dynamic instance) => instance.value,
        r'id': (dynamic instance) => instance.id,
        r'token': (dynamic instance) => instance.token,
        r'expiration': (dynamic instance) => instance.expiration,
        r'refreshToken': (dynamic instance) => instance.refreshToken,
        r'firstName': (dynamic instance) => instance.firstName,
        r'lastName': (dynamic instance) => instance.lastName,
        r'refreshTokenValue': (dynamic instance) => instance.refreshTokenValue,
        r'refreshTokenEndDate': (dynamic instance) =>
            instance.refreshTokenEndDate,
        r'clientId': (dynamic instance) => instance.clientId,
        r'clientName': (dynamic instance) => instance.clientName,
        r'jsonData': (dynamic instance) => instance.jsonData,
        r'userId': (dynamic instance) => instance.userId,
        r'claimId': (dynamic instance) => instance.claimId,
        r'languageCode': (dynamic instance) => instance.languageCode,
        r'languageName': (dynamic instance) => instance.languageName,
        r'name': (dynamic instance) => instance.name,
        r'claims': (dynamic instance) => instance.claims,
        r'status': (dynamic instance) => instance.status
      },
      {
        r'email=': (dynamic instance, value) => instance.email = value,
        r'password=': (dynamic instance, value) => instance.password = value,
        r'languageId=': (dynamic instance, value) =>
            instance.languageId = value,
        r'key=': (dynamic instance, value) => instance.key = value,
        r'value=': (dynamic instance, value) => instance.value = value,
        r'id=': (dynamic instance, value) => instance.id = value,
        r'token=': (dynamic instance, value) => instance.token = value,
        r'expiration=': (dynamic instance, value) =>
            instance.expiration = value,
        r'refreshToken=': (dynamic instance, value) =>
            instance.refreshToken = value,
        r'firstName=': (dynamic instance, value) => instance.firstName = value,
        r'lastName=': (dynamic instance, value) => instance.lastName = value,
        r'refreshTokenValue=': (dynamic instance, value) =>
            instance.refreshTokenValue = value,
        r'refreshTokenEndDate=': (dynamic instance, value) =>
            instance.refreshTokenEndDate = value,
        r'clientId=': (dynamic instance, value) => instance.clientId = value,
        r'clientName=': (dynamic instance, value) =>
            instance.clientName = value,
        r'jsonData=': (dynamic instance, value) => instance.jsonData = value,
        r'userId=': (dynamic instance, value) => instance.userId = value,
        r'claimId=': (dynamic instance, value) => instance.claimId = value,
        r'languageCode=': (dynamic instance, value) =>
            instance.languageCode = value,
        r'languageName=': (dynamic instance, value) =>
            instance.languageName = value,
        r'name=': (dynamic instance, value) => instance.name = value,
        r'claims=': (dynamic instance, value) => instance.claims = value,
        r'status=': (dynamic instance, value) => instance.status = value
      },
      null,
      [
        const [0, 0, null],
        const [1, 0, null],
        const [2, 0, null],
        const [3, 0, null],
        const [4, 0, null],
        const [5, 0, null]
      ])
};

final _memberSymbolMap = null;

void initializeReflectable() {
  r.data = _data;
  r.memberSymbolMap = _memberSymbolMap;
}
