[PFP Admob �̽� ���]
���� ����Ʈ
-https://github.com/googleads/googleads-mobile-plugins/blob/master/unity/README.md

[Android]

-------------------------ECIPSE Main Activity-----------------------
1.



--------------------------Manifest ����-----------------

https://developers.google.com/mobile-ads-sdk/docs/#play

1. 
 <activity
            android:name="com.pfp.pfpadmoblib.PFPAdmobPluginActivity"
            android:label="@string/app_name" >
        </activity>

���� activity�� �߰��� �����.

2. 
meta ������ �߰�
<meta-data android:name="com.google.android.gms.version"
               android:value="@integer/google_play_services_version"/>

�Ļ��Ǵ� ���� 1
<meta-data android:name="com.google.android.gms.version"
               android:value="@integer/google_play_services_version"/>
���� @integer ���� �ذ��

google-play-services_lib ������Ʈ�� res/values/version.xml�� �ڽ��� ������Ʈ�� ����


3.<activity android:name="com.google.android.gms.ads.AdActivity"
             android:configChanges="keyboard|keyboardHidden|orientation|screenLayout|uiMode|screenSize|smallestScreenSize"/>
�߰�

-------------------------BUILD-------------------------------

����� ��� ������ �߻��ϴ� ��� ����

1. error building player: wind32exception: applicationname ~~~~~~~   zipalign.exe Ȥ�� package_unaligned   

�� ������ eclipse�� sdk ���� ������ build-tools ��򰡿��� zipalign.exe �� ����,
sdk/tools/ �� ��ġ�ؾ���.



--------------------------PLUGIN------------------------------

1. 
Plugins/Android/libs�� google-play-services ��ġ (����� 3���� ��ȣ�� ��Ī�Ǵ� ������ �־����. modules/admob/plugins/android/libs/google-play-services ���)
Plugins/Android/libs�� android-support-v4 ��ġ

2. 
Plugins/Android/ �� unity-plugin-library ��ġ
Plugins/Android/ �� PFP_AdmobPlugin ��ġ

3. 
Plugins/Android/res/values/version.xml  (modules/admob/plugins/android/res/values/version.xml ��� ����)
������
<?xml version="1.0" encoding="utf-8"?>
<resources>
    <integer name="google_play_services_version">5077000</integer>
</resources>
