using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using Prime31;

public class PaymentManager : MonoBehaviour {

	protected Dictionary<int, string> GoogleBalanceToSkuID = new Dictionary<int, string>();
	protected Dictionary<string, string> GoogleSkuList = new Dictionary<string, string>();
	protected Dictionary<string, string> iOSSkuList = new Dictionary<string, string>();
	protected Dictionary<string, string> PaymentInfoPriceDictionary_US = new Dictionary<string, string>();
	protected Dictionary<string, string> PaymentInfoPriceDictionary_KR = new Dictionary<string, string>();
	protected Dictionary<string, string> PaymentInfoPriceDictionary_JA = new Dictionary<string, string>();
	//protected Dictionary<string, 

	[HideInInspector]
	public delegate void PaymentManagerOkDelegate(string returnProductIdentifier); 
	protected PaymentManagerOkDelegate _paymentManagerOkDelegate ;
	public event PaymentManagerOkDelegate PaymentManagerOkEvent {
		add{
			
			_paymentManagerOkDelegate = null ;
			
			if (_paymentManagerOkDelegate == null)
        		_paymentManagerOkDelegate += value;
        }
		
		remove{
            _paymentManagerOkDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void PaymentManagerErrorDelegate(string errorMessage, int state); 
	protected PaymentManagerErrorDelegate _paymentManagerErrorDelegate ;
	public event PaymentManagerErrorDelegate PaymentManagerErrorEvent {
		add{
			
			_paymentManagerErrorDelegate = null ;
			
			if (_paymentManagerErrorDelegate == null)
        		_paymentManagerErrorDelegate += value;
        }
		
		remove{
            _paymentManagerErrorDelegate -= value;
		}
	}
	
#if UNITY_ANDROID 
	//------
	[HideInInspector]
	public delegate void PaymentManagerConsumeOkDelegate(string returnProductIdentifier); 
	protected PaymentManagerConsumeOkDelegate _paymentManagerConsumeOkDelegate ;
	public event PaymentManagerConsumeOkDelegate PaymentManagerConsumeOkEvent {
		add{
			
			_paymentManagerConsumeOkDelegate = null ;
			
			if (_paymentManagerConsumeOkDelegate == null)
        		_paymentManagerConsumeOkDelegate += value;
        }
		
		remove{
            _paymentManagerConsumeOkDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void PaymentManagerConsumeErrorDelegate(); 
	protected PaymentManagerConsumeErrorDelegate _paymentManagerConsumeErrorDelegate ;
	public event PaymentManagerConsumeErrorDelegate PaymentManagerConsumeErrorEvent {
		add{
			
			_paymentManagerConsumeErrorDelegate = null ;
			
			if (_paymentManagerConsumeErrorDelegate == null)
        		_paymentManagerConsumeErrorDelegate += value;
        }
		
		remove{
            _paymentManagerConsumeErrorDelegate -= value;
		}
	}
	
	//------
	[HideInInspector]
	public delegate void PaymentManagerQueryInventoryOkDelegate(List<GooglePurchase> purchases); 
	protected PaymentManagerQueryInventoryOkDelegate _paymentManagerQueryInventoryOkDelegate ;
	public event PaymentManagerQueryInventoryOkDelegate PaymentManagerQueryInventoryOkEvent {
		add{
			
			_paymentManagerQueryInventoryOkDelegate = null ;
			
			if (_paymentManagerQueryInventoryOkDelegate == null)
        		_paymentManagerQueryInventoryOkDelegate += value;
        }
		
		remove{
            _paymentManagerQueryInventoryOkDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void PaymentManagerQueryInventoryErrorDelegate(); 
	protected PaymentManagerQueryInventoryErrorDelegate _paymentManagerQueryInventoryErrorDelegate ;
	public event PaymentManagerQueryInventoryErrorDelegate PaymentManagerQueryInventoryErrorEvent {
		add{
			
			_paymentManagerQueryInventoryErrorDelegate = null ;
			
			if (_paymentManagerQueryInventoryErrorDelegate == null)
        		_paymentManagerQueryInventoryErrorDelegate += value;
        }
		
		remove{
            _paymentManagerQueryInventoryErrorDelegate -= value;
		}
	}
#endif	
	
	
	
	private bool _isPayment = false ;
	
#if UNITY_IPHONE	
	// IAP Module..
	private List<StoreKitProduct> _products;
#elif UNITY_ANDROID 
	
#endif	
	
	private void Awake(){
		Initialize();
#if UNITY_IPHONE
		// IAP Module..
		var productIdentifiers = new string[] { "com.polycube.st200.Bullion.10", "com.polycube.st200.Bullion.33", "com.polycube.st200.Bullion.60", "com.polycube.st200.Bullion.130", "com.polycube.st200.Bullion.420", "com.polycube.st200.Bullion.750" };
		StoreKitBinding.requestProductData( productIdentifiers );
#elif UNITY_ANDROID 
		var key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhTzuulU3SGashsszdsirruxWLPRX+01HUr5FaDVwusYl/NxqwzI7dCC0yEfOi6i/mZv2K0yW/zHWXZ6s09liZaysRJzqAMIYLnHYh463FWPaCP2hspo6XsgkJXnA1Qtljq4bnR4nGGJVzITIiXey1v3EHN3t/0gYpizoDSp3s9DIEz3geggFv50skQ0hUdj8KSHtQV+1O7J/mOIQZoIXrDF2D/wqaurVOWw/cNj26ju4Ge+T6SsL5MU7vQKHcjgok/sJMvldkjEO0WIAXdZvXck5EXEvMNMLt/uWa+5+uBZxVba+jkKshskRrfcCkBIxHmOMUZhjkM92hUdreDNDZQIDAQAB";
		GoogleIAB.init( key );
#endif
	}
	
	
	private void Start(){
#if UNITY_IPHONE		
		// IAP Module..
		StoreKitManager.productListReceivedEvent += allProducts =>
		{
			//Debug.Log( "received total products: " + allProducts.Count );
			_products = allProducts;
		};

#elif UNITY_ANDROID 
		
		var skus = new string[] { "st200_gold_10", "st200_gold_30", "st200_gold_50", "st200_gold_100", "st200_gold_300", "st200_gold_500"};
		GoogleIAB.queryInventory( skus );
		
#endif
		
//		Managers.DataStream.DataStreamIAPOkManagerEvent += DataStreamIAPOkManagerDelegate ;
//		Managers.DataStream.DataStreamIAPErrorManagerEvent += DataStreamIAPErrorManagerDelegate ;
		
	}

	void OnEnable() {
#if UNITY_IPHONE
		// Listens to all the StoreKit events.  All event listeners MUST be removed before this object is disposed!
		StoreKitManager.productPurchaseAwaitingConfirmationEvent += productPurchaseAwaitingConfirmationEvent;
		StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
		StoreKitManager.purchaseCancelledEvent += purchaseCancelled;
		StoreKitManager.purchaseFailedEvent += purchaseFailed;
		StoreKitManager.productListReceivedEvent += productListReceivedEvent;
		StoreKitManager.productListRequestFailedEvent += productListRequestFailed;
#elif UNITY_ANDROID 
		GoogleIABManager.billingSupportedEvent += billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent += billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent += purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent += purchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
#endif
	}
	
	
	void OnDisable() {
#if UNITY_IPHONE
		// Listens to all the StoreKit events.  All event listeners MUST be removed before this object is disposed!
		StoreKitManager.productPurchaseAwaitingConfirmationEvent -= productPurchaseAwaitingConfirmationEvent;
		StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
		StoreKitManager.purchaseCancelledEvent -= purchaseCancelled;
		StoreKitManager.purchaseFailedEvent -= purchaseFailed;
		StoreKitManager.productListReceivedEvent -= productListReceivedEvent;
		StoreKitManager.productListRequestFailedEvent -= productListRequestFailed;
#elif UNITY_ANDROID 
		GoogleIABManager.billingSupportedEvent -= billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent -= billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent -= purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent -= purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent -= purchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
#endif
	}
	void Initialize()
	{
		GoogleBalanceToSkuID = new Dictionary<int, string>();
		GoogleBalanceToSkuID.Add(1, "st200_gold_10");
		GoogleBalanceToSkuID.Add(2, "st200_gold_30");
		GoogleBalanceToSkuID.Add(3, "st200_gold_50");
		GoogleBalanceToSkuID.Add(4, "st200_gold_100");
		GoogleBalanceToSkuID.Add(5, "st200_gold_300");
		GoogleBalanceToSkuID.Add(6, "st200_gold_500");

		PaymentInfoPriceDictionary_US.Add("st200_gold_10", "$0.99");
		PaymentInfoPriceDictionary_US.Add("st200_gold_30", "$2.99");
		PaymentInfoPriceDictionary_US.Add("st200_gold_50", "$4.99");
		PaymentInfoPriceDictionary_US.Add("st200_gold_100", "$9.99");
		PaymentInfoPriceDictionary_US.Add("st200_gold_300", "$29.99");
		PaymentInfoPriceDictionary_US.Add("st200_gold_500", "$49.99");
		
		PaymentInfoPriceDictionary_KR.Add("st200_gold_10", "₩1,100");
		PaymentInfoPriceDictionary_KR.Add("st200_gold_30", "₩3,300");
		PaymentInfoPriceDictionary_KR.Add("st200_gold_50", "₩5,500");
		PaymentInfoPriceDictionary_KR.Add("st200_gold_100", "₩11,000");
		PaymentInfoPriceDictionary_KR.Add("st200_gold_300", "₩33,000");
		PaymentInfoPriceDictionary_KR.Add("st200_gold_500", "₩55,000");
	}
	
#if UNITY_IPHONE
	//-- Deleagate
	void productListReceivedEvent( List<StoreKitProduct> productList )
	{
		//Debug.Log( "productListReceivedEvent. total products received: " + productList.Count );
		
		// print the products to the console
		foreach( StoreKitProduct product in productList )
		{
			//Debug.Log( product.ToString() + "\n" );
		}
		
		_isPayment = true ;
	}
	
	void productListRequestFailed( string error )
	{
		//Debug.Log( "productListRequestFailed: " + error );
		
		_isPayment = false ;
	}
	
	void purchaseFailed( string error )
	{
		//Debug.Log( "purchase failed with error: " + error );
		
		if(_paymentManagerErrorDelegate != null){
			_paymentManagerErrorDelegate(error, 1) ; //1: 통신이 원활하지 않습니다. 다시 결제해주세요.
		}
		
	}
	

	void purchaseCancelled( string error )
	{
		//Debug.Log( "purchase cancelled with error: " + error );
		
		if(_paymentManagerErrorDelegate != null){
			_paymentManagerErrorDelegate(error, 2) ; //2: 결제가 취소 되었습니다.	
		}
		
	}
	
	
	void productPurchaseAwaitingConfirmationEvent( StoreKitTransaction transaction )
	{
		//Debug.Log( "productPurchaseAwaitingConfirmationEvent: " + transaction );
		//Nothing..!!????
	}
	
	
	void purchaseSuccessful( StoreKitTransaction transaction )
	{
		//Debug.Log( "purchased product: " + transaction );
		
		
		Managers.DataStream.DataStreamIAPOkManagerEvent += (productIdentifier, state) => {
			if(_paymentManagerOkDelegate != null){
				_paymentManagerOkDelegate(productIdentifier) ;
			}
		};
		
		Managers.DataStream.DataStreamIAPErrorManagerEvent += (sendMode, state) => {
			if(state == 111){
				//3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				if(_paymentManagerErrorDelegate != null){
					_paymentManagerErrorDelegate("Error", 3) ; //3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				}
			}else if(state == 112){
				//1: 통신이 원활하지 않습니다. 다시 결제해주세요.
				if(_paymentManagerErrorDelegate != null){
					_paymentManagerErrorDelegate("Error", 1) ; //1: 통신이 원활하지 않습니다. 다시 결제해주세요.
				}
			}
		};
		
		// 
		StartCoroutine(Managers.DataStream.SendIAPValidateReceipt(transaction)) ;
		//
		
	}
	
#elif UNITY_ANDROID 
	void billingSupportedEvent()
	{
		//Debug.Log( "billingSupportedEvent" );
		
		_isPayment = true ;
		
		//GoogleIAB.enableLogging( true );
		GoogleIAB.enableLogging( false );

	}


	void billingNotSupportedEvent( string error )
	{
		//Debug.Log( "billingNotSupportedEvent: " + error );
		
		_isPayment = false ;
	}
	
	void queryInventorySucceededEvent( List<GooglePurchase> purchases, List<GoogleSkuInfo> skus )
	{
		//Debug.Log( string.Format( "queryInventorySucceededEvent. total purchases: {0}, total skus: {1}", purchases.Count, skus.Count ) );
		Prime31.Utils.logObject( purchases );
		Prime31.Utils.logObject( skus );

		GoogleSkuList = new Dictionary<string, string>();
		for(int i = 0; i < skus.Count; i++)
		{
			GoogleSkuInfo curinfo = skus[i];
			GoogleSkuList.Add(curinfo.productId, curinfo.price);
		}

		if(_paymentManagerQueryInventoryOkDelegate != null){
			_paymentManagerQueryInventoryOkDelegate(purchases) ;
		}
		
		/*
		if ( purchases.Count > 0 ){	
			for ( int i = 0 ; i < purchases.Count ; i ++ ){
				GoogleIAB.consumeProduct(purchases[i].productId);
			}
		}
		*/
		
	}


	void queryInventoryFailedEvent( string error )
	{
		//Debug.Log( "queryInventoryFailedEvent: " + error );
		
		if(_paymentManagerQueryInventoryErrorDelegate != null){
			_paymentManagerQueryInventoryErrorDelegate() ;	
		}
		
	}
	
	void purchaseCompleteAwaitingVerificationEvent( string purchaseData, string signature )
	{
		//Debug.Log( "purchaseCompleteAwaitingVerificationEvent. purchaseData: " + purchaseData + ", signature: " + signature );
		//Nothing..
	}
	

	void purchaseSucceededEvent( GooglePurchase purchase )
	{
		//Debug.Log( "purchaseSucceededEvent: " + purchase );
		
		Managers.DataStream.DataStreamIAPOkManagerEvent += (productIdentifier, state) => {
			if(_paymentManagerOkDelegate != null){
				_paymentManagerOkDelegate(productIdentifier) ;
			}
		};
		
		Managers.DataStream.DataStreamIAPErrorManagerEvent += (sendMode, state) => {
			Debug.Log("?? THIS???: sEND MODE: " + sendMode + " STATE: " + state);
			if(state == 111){
				//3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				if(_paymentManagerErrorDelegate != null){
					_paymentManagerErrorDelegate("Error", 3) ; //3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
				}
			}else if(state == 112){
				//1: 통신이 원활하지 않습니다. 다시 결제해주세요.
				if(_paymentManagerErrorDelegate != null){
					_paymentManagerErrorDelegate("Error", 1) ; //1: 통신이 원활하지 않습니다. 다시 결제해주세요.
				}
			}
		};
		
		// 
		StartCoroutine(Managers.DataStream.SendIABValidateReceipt(purchase)) ;
		//
		
	}


	void purchaseFailedEvent( string error )
	{
		//Debug.Log( "purchaseFailedEvent: " + error );
		if(_paymentManagerErrorDelegate != null){
			_paymentManagerErrorDelegate(error, 1) ; //1: 통신이 원활하지 않습니다. 다시 결제해주세요.
		}
	}


	void consumePurchaseSucceededEvent(GooglePurchase purchase )
	{
		//Debug.Log( "consumePurchaseSucceededEvent: " + purchase );
		
		if(_paymentManagerConsumeOkDelegate != null){
			_paymentManagerConsumeOkDelegate(purchase.productId) ;
		}
	}


	void consumePurchaseFailedEvent( string error )
	{
		//Debug.Log( "consumePurchaseFailedEvent: " + error );
		
		if(_paymentManagerConsumeErrorDelegate != null){
			_paymentManagerConsumeErrorDelegate() ;	
		}
	}
	
#endif
	
	/*
	private void DataStreamIAPOkManagerDelegate(string productIdentifier, int state) {
		
		if(_paymentManagerOkDelegate != null){
			_paymentManagerOkDelegate(productIdentifier) ;
		}
		
	}
	
	private void DataStreamIAPErrorManagerDelegate(string sendMode, int state) {
		if(state == 111){
			//3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
			if(_paymentManagerErrorDelegate != null){
				_paymentManagerErrorDelegate("Error", 3) ; //3: 데이터가 올바르지 않습니다. 다시 실행해 주세요.
			}
		}else if(state == 112){
			//1: 통신이 원활하지 않습니다. 다시 결제해주세요.
			if(_paymentManagerErrorDelegate != null){
				_paymentManagerErrorDelegate("Error", 1) ; //1: 통신이 원활하지 않습니다. 다시 결제해주세요.
			}
		}
	}
	*/
	
	
	
	
	public void PurchaseProduct(string productIdentifier, int quantity){
		
#if UNITY_IPHONE

		// ========== iOS 결재 모듈 수정부분 (by 최원석14.04.18 ) START ==========
		if (!_isPayment){
			// IAP Module..
			var productIdentifiers = new string[] { 
				"com.polycube.st200.Bullion.10",
				"com.polycube.st200.Bullion.33",
				"com.polycube.st200.Bullion.60", 
				"com.polycube.st200.Bullion.130",
				"com.polycube.st200.Bullion.420",
				"com.polycube.st200.Bullion.750" };
			// ========== iOS 결재 모듈 수정부분 (by 최원석14.04.18 ) END ==========

			StoreKitBinding.requestProductData( productIdentifiers );
			
			StoreKitManager.productListReceivedEvent += allProducts =>
			{
				//Debug.Log( "received total products: " + allProducts.Count );
				_products = allProducts;
			};
		}
		
		bool isExistProduct = false ;
		for(int i = 0 ; i < _products.Count ; i++) {
			var product = _products[i] ;
			if(product.productIdentifier.Equals(productIdentifier)){
				isExistProduct = true ;
				break ;
			}
		}
					
		if(isExistProduct){
			StoreKitBinding.purchaseProduct(productIdentifier, 1 );	
		}else{
			// ERROR... 
			// 해당 상품이 존재 하지 않습니다.
			if(_paymentManagerErrorDelegate != null){
				_paymentManagerErrorDelegate("Not Exsit Product", 1) ; //1: 통신이 원활하지 않습니다. 다시 결제해주세요.
			}
		}
		
#elif UNITY_ANDROID 
		
		if(!_isPayment){
			var key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhTzuulU3SGashsszdsirruxWLPRX+01HUr5FaDVwusYl/NxqwzI7dCC0yEfOi6i/mZv2K0yW/zHWXZ6s09liZaysRJzqAMIYLnHYh463FWPaCP2hspo6XsgkJXnA1Qtljq4bnR4nGGJVzITIiXey1v3EHN3t/0gYpizoDSp3s9DIEz3geggFv50skQ0hUdj8KSHtQV+1O7J/mOIQZoIXrDF2D/wqaurVOWw/cNj26ju4Ge+T6SsL5MU7vQKHcjgok/sJMvldkjEO0WIAXdZvXck5EXEvMNMLt/uWa+5+uBZxVba+jkKshskRrfcCkBIxHmOMUZhjkM92hUdreDNDZQIDAQAB";
			GoogleIAB.init( key );
		}
		
		//GoogleIAB.consumeProduct(productIdentifier) ;
		
		GoogleIAB.purchaseProduct( productIdentifier) ;
		
#endif
		
	}

	
	
	public void QueryInventoryProduct(){
#if UNITY_IPHONE
		
#elif UNITY_ANDROID 
		
		if(!_isPayment){
			var key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhTzuulU3SGashsszdsirruxWLPRX+01HUr5FaDVwusYl/NxqwzI7dCC0yEfOi6i/mZv2K0yW/zHWXZ6s09liZaysRJzqAMIYLnHYh463FWPaCP2hspo6XsgkJXnA1Qtljq4bnR4nGGJVzITIiXey1v3EHN3t/0gYpizoDSp3s9DIEz3geggFv50skQ0hUdj8KSHtQV+1O7J/mOIQZoIXrDF2D/wqaurVOWw/cNj26ju4Ge+T6SsL5MU7vQKHcjgok/sJMvldkjEO0WIAXdZvXck5EXEvMNMLt/uWa+5+uBZxVba+jkKshskRrfcCkBIxHmOMUZhjkM92hUdreDNDZQIDAQAB";
			GoogleIAB.init( key );
		}
		
		var skus = new string[] { "st200_gold_10", "st200_gold_30", "st200_gold_50", "st200_gold_100", "st200_gold_300", "st200_gold_500"};
		GoogleIAB.queryInventory( skus );

#endif
		
	}
	
	
	
	public void ConsumeProduct(string productIdentifier){
		//Debug.Log("COPNSUME CALLED");
#if UNITY_IPHONE
		
#elif UNITY_ANDROID 

		if(!_isPayment){
			var key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhTzuulU3SGashsszdsirruxWLPRX+01HUr5FaDVwusYl/NxqwzI7dCC0yEfOi6i/mZv2K0yW/zHWXZ6s09liZaysRJzqAMIYLnHYh463FWPaCP2hspo6XsgkJXnA1Qtljq4bnR4nGGJVzITIiXey1v3EHN3t/0gYpizoDSp3s9DIEz3geggFv50skQ0hUdj8KSHtQV+1O7J/mOIQZoIXrDF2D/wqaurVOWw/cNj26ju4Ge+T6SsL5MU7vQKHcjgok/sJMvldkjEO0WIAXdZvXck5EXEvMNMLt/uWa+5+uBZxVba+jkKshskRrfcCkBIxHmOMUZhjkM92hUdreDNDZQIDAQAB";
			GoogleIAB.init( key );
		}
		
		GoogleIAB.consumeProduct(productIdentifier) ;

#endif
		
	}

	public string GetProductCost(int _balanceindex, string _balanceprice)
	{
		//string price = "";

#if UNITY_ANDROID
		if(Constant.CURRENT_MARKET == "2")
		{
			if(Managers.CountryCode == "kr")
			{
				if(PaymentInfoPriceDictionary_KR.ContainsKey(GoogleBalanceToSkuID[_balanceindex]))
				{
					return PaymentInfoPriceDictionary_KR[GoogleBalanceToSkuID[_balanceindex]];	
				}
			}else
			{
				if(PaymentInfoPriceDictionary_US.ContainsKey(GoogleBalanceToSkuID[_balanceindex]))
				{
					return PaymentInfoPriceDictionary_US[GoogleBalanceToSkuID[_balanceindex]];
				}
			}
			//if(GoogleSkuList.ContainsKey(GoogleBalanceToSkuID[_balanceindex]))
			//{			  
			//	return GoogleSkuList[GoogleBalanceToSkuID[_balanceindex]];
			//}else
			//{
			//	return "no data";
			//}
		}
#endif

		return _balanceprice;
	}
}



