[PFP Admob 이식 방법]
참고 사이트
-https://github.com/googleads/googleads-mobile-plugins/blob/master/unity/README.md

[Android]

-------------------------ECIPSE Main Activity-----------------------
1.



--------------------------Manifest 설정-----------------

https://developers.google.com/mobile-ads-sdk/docs/#play

1. 
 <activity
            android:name="com.pfp.pfpadmoblib.PFPAdmobPluginActivity"
            android:label="@string/app_name" >
        </activity>

다음 activity를 추가해 줘야함.

2. 
meta 데이터 추가
<meta-data android:name="com.google.android.gms.version"
               android:value="@integer/google_play_services_version"/>

파생되는 문제 1
<meta-data android:name="com.google.android.gms.version"
               android:value="@integer/google_play_services_version"/>
에서 @integer 문제 해결법

google-play-services_lib 프로젝트의 res/values/version.xml을 자신의 프로젝트에 세팅


3.<activity android:name="com.google.android.gms.ads.AdActivity"
             android:configChanges="keyboard|keyboardHidden|orientation|screenLayout|uiMode|screenSize|smallestScreenSize"/>
추가

-------------------------BUILD-------------------------------

빌드시 몇가지 오류가 발생하는 경우 존재

1. error building player: wind32exception: applicationname ~~~~~~~   zipalign.exe 혹은 package_unaligned   

이 문제는 eclipse의 sdk 폴더 내부의 build-tools 어딘가에서 zipalign.exe 를 복사,
sdk/tools/ 에 배치해야함.



--------------------------PLUGIN------------------------------

1. 
Plugins/Android/libs에 google-play-services 배치 (요놈은 3번에 번호와 매칭되는 파일을 넣어야함. modules/admob/plugins/android/libs/google-play-services 사용)
Plugins/Android/libs에 android-support-v4 배치

2. 
Plugins/Android/ 에 unity-plugin-library 배치
Plugins/Android/ 에 PFP_AdmobPlugin 배치

3. 
Plugins/Android/res/values/version.xml  (modules/admob/plugins/android/res/values/version.xml 사용 권장)
내용은
<?xml version="1.0" encoding="utf-8"?>
<resources>
    <integer name="google_play_services_version">5077000</integer>
</resources>
