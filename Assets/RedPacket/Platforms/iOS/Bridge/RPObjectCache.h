#import <Foundation/Foundation.h>

@interface RPObjectCache : NSObject

+ (instancetype)sharedInstance;

@property(nonatomic, strong) NSMutableDictionary *references;

@end

@interface NSObject (RPOwnershipAdditions)

- (NSString *)rp_referenceKey;

@end
